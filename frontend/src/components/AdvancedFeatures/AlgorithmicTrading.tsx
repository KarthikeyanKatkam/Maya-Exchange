import React, { useState, useEffect } from 'react';
import { Card, Form, Button, Alert, Table } from 'react-bootstrap';
import { useWeb2 } from '../../hooks/useWeb2';
import useWeb3 from '../../hooks/useWeb3';
import { AlgorithmicTradingService } from '../../services/algorithmicTrading.service';
import { formatCurrency } from '../../utils/formatters';
import styles from './AdvancedFeatures.module.css';

interface AlgorithmicTradingProps {
  tradingPair: string;
}

const AlgorithmicTrading: React.FC<AlgorithmicTradingProps> = ({ tradingPair }) => {
  const [strategy, setStrategy] = useState<string>('');
  const [investment, setInvestment] = useState<number>(0);
  const [timeframe, setTimeframe] = useState<string>('1h');
  const [stopLoss, setStopLoss] = useState<number>(0);
  const [takeProfit, setTakeProfit] = useState<number>(0);
  const [activeStrategies, setActiveStrategies] = useState<any[]>([]);
  const [error, setError] = useState<string>('');
  const [success, setSuccess] = useState<string>('');
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const { account } = useWeb2();
  const algoTradingService = new AlgorithmicTradingService();

  useEffect(() => {
    loadActiveStrategies();
  }, [account, tradingPair]);

  const loadActiveStrategies = async () => {
    try {
      if (!account) {
        setError('Please connect your wallet');
        return;
      }
      const strategies = await algoTradingService.getActiveStrategies(account, tradingPair);
      setActiveStrategies(strategies);
    } catch (err) {
      setError('Failed to load active trading strategies');
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');
    setSuccess('');
    setIsLoading(true);
    try {
      if (!account) {
        throw new Error('Please connect your wallet');
      }
      if (!strategy) {
        throw new Error('Please select a trading strategy');
      }
      const result = await algoTradingService.createStrategy({
        account,
        tradingPair,
        strategy,
        investment,
        timeframe,
        stopLoss,
        takeProfit,
      });
      setSuccess('Trading strategy created successfully');
      loadActiveStrategies();
    } catch (err: any) {
      setError(err.message || 'Failed to create trading strategy');
    } finally {
      setIsLoading(false);
    }
  };

  const handleStopStrategy = async (strategyId: string) => {
    try {
      await algoTradingService.stopStrategy(strategyId);
      setSuccess('Strategy stopped successfully');
      loadActiveStrategies();
    } catch (err) {
      setError('Failed to stop trading strategy');
    }
  };

  return (
    <Card className={styles.featureCard}>
      <Card.Header>
        <h4 className={styles.featureHeader}>Algorithmic Trading</h4>
      </Card.Header>
      <Card.Body>
        {error && <Alert variant="danger">{error}</Alert>}
        {success && <Alert variant="success">{success}</Alert>}
        <Form onSubmit={handleSubmit}>
          <Form.Group className={styles.formGroup}>
            <Form.Label className={styles.formLabel}>Trading Strategy</Form.Label>
            <Form.Select
              className={styles.formInput}
              value={strategy}
              onChange={(e) => setStrategy(e.target.value)}
              required
            >
              <option value="">Select Strategy</option>
              <option value="MACD">MACD Crossover</option>
              <option value="RSI">RSI Divergence</option>
              <option value="BB">Bollinger Bands</option>
              <option value="MA">Moving Average Crossover</option>
            </Form.Select>
          </Form.Group>
          <Form.Group className={styles.formGroup}>
            <Form.Label className={styles.formLabel}>Investment Amount</Form.Label>
            <Form.Control
              className={styles.formInput}
              type="number"
              value={investment}
              onChange={(e) => setInvestment(Number(e.target.value))}
              required
              min={0}
            />
          </Form.Group>
          <Form.Group className={styles.formGroup}>
            <Form.Label className={styles.formLabel}>Timeframe</Form.Label>
            <Form.Select
              className={styles.formInput}
              value={timeframe}
              onChange={(e) => setTimeframe(e.target.value)}
              required
            >
              <option value="1m">1 minute</option>
              <option value="5m">5 minutes</option>
              <option value="15m">15 minutes</option>
              <option value="1h">1 hour</option>
              <option value="4h">4 hours</option>
              <option value="1d">1 day</option>
            </Form.Select>
          </Form.Group>
          <Form.Group className={styles.formGroup}>
            <Form.Label className={styles.formLabel}>Stop Loss (%)</Form.Label>
            <Form.Control
              className={styles.formInput}
              type="number"
              value={stopLoss}
              onChange={(e) => setStopLoss(Number(e.target.value))}
              required
              min={0}
              max={100}
            />
          </Form.Group>
          <Form.Group className={styles.formGroup}>
            <Form.Label className={styles.formLabel}>Take Profit (%)</Form.Label>
            <Form.Control
              className={styles.formInput}
              type="number"
              value={takeProfit}
              onChange={(e) => setTakeProfit(Number(e.target.value))}
              required
              min={0}
            />
          </Form.Group>
          <Button
            type="submit"
            className={styles.primaryButton}
            disabled={isLoading}
          >
            {isLoading ? (
              <>
                <span className={styles.loadingSpinner}></span>
                Creating Strategy...
              </>
            ) : (
              'Create Strategy'
            )}
          </Button>
        </Form>
        <hr />
        <h5 className={styles.featureHeader}>Active Strategies</h5>
        <div className={styles.tradingTable}>
          <Table striped bordered hover responsive>
            <thead>
              <tr>
                <th>Strategy</th>
                <th>Investment</th>
                <th>Timeframe</th>
                <th>P/L</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody>
              {activeStrategies.map((strat) => (
                <tr key={strat.id}>
                  <td>{strat.strategy}</td>
                  <td>{formatCurrency(strat.investment.toString(), 2)}</td>
                  <td>{strat.timeframe}</td>
                  <td className={strat.pl >= 0 ? styles.successBadge : styles.errorBadge}>
                    {formatCurrency(strat.pl.toString(), 2)}
                  </td>
                  <td>
                    <Button
                      variant="danger"
                      size="sm"
                      className={styles.secondaryButton}
                      onClick={() => handleStopStrategy(strat.id)}
                    >
                      Stop
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </div>
      </Card.Body>
    </Card>
  );
};

export default AlgorithmicTrading;