import React, { useState, useEffect } from 'react';
import { Card, Form, Button, Alert, Table } from 'react-bootstrap';
import { useWeb2 } from '../../hooks/useWeb3';
import { GridTradingService } from '../../services/gridTrading.service';
import { formatCurrency } from '../../utils/formatters';

interface GridTradingProps {
  tradingPair: string;
}

const GridTrading: React.FC<GridTradingProps> = ({ tradingPair }) => {
  const [upperPrice, setUpperPrice] = useState<number>(0);
  const [lowerPrice, setLowerPrice] = useState<number>(0);
  const [gridLines, setGridLines] = useState<number>(0);
  const [investment, setInvestment] = useState<number>(0);
  const [activeGrids, setActiveGrids] = useState<any[]>([]);
  const [error, setError] = useState<string>('');
  const [success, setSuccess] = useState<string>('');
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const { account } = useWeb2();
  const gridTradingService = new GridTradingService();

  useEffect(() => {
    loadActiveGrids();
  }, [account, tradingPair]);

  const loadActiveGrids = async () => {
    try {
      if (account) {
        const grids = await gridTradingService.getActiveGrids(account, tradingPair);
        setActiveGrids(grids);
      } else {
        setError('Account is not available');
      }
    } catch (err) {
      setError('Failed to load active grid positions');
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

      if (upperPrice <= lowerPrice) {
        throw new Error('Upper price must be greater than lower price');
      }

      if (gridLines < 3) {
        throw new Error('Minimum 2 grid lines required');
      }

      const gridParams = {
        upperPrice,
        lowerPrice,
        gridLines,
        investment,
        tradingPair,
        account
      };

      await gridTradingService.createGridStrategy(gridParams);
      setSuccess('Grid trading strategy created successfully');
      loadActiveGrids();
    } catch (err: any) {
      setError(err.message || 'Failed to create grid strategy');
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <Card className="mb-3">
      <Card.Header>
        <h5>Grid Trading</h5>
      </Card.Header>
      <Card.Body>
        {error && <Alert variant="danger">{error}</Alert>}
        {success && <Alert variant="success">{success}</Alert>}

        <Form onSubmit={handleSubmit}>
          <Form.Group className="mb-3">
            <Form.Label>Upper Price</Form.Label>
            <Form.Control
              type="number"
              value={upperPrice}
              onChange={(e) => setUpperPrice(Number(e.target.value))}
              required
            />
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Lower Price</Form.Label>
            <Form.Control
              type="number"
              value={lowerPrice}
              onChange={(e) => setLowerPrice(Number(e.target.value))}
              required
            />
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Number of Grid Lines</Form.Label>
            <Form.Control
              type="number"
              value={gridLines}
              onChange={(e) => setGridLines(Number(e.target.value))}
              required
              min="3"
            />
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Total Investment</Form.Label>
            <Form.Control
              type="number"
              value={investment}
              onChange={(e) => setInvestment(Number(e.target.value))}
              required
            />
          </Form.Group>

          <Button type="submit" disabled={isLoading}>
            {isLoading ? 'Creating Grid...' : 'Create Grid Strategy'}
          </Button>
        </Form>

        {activeGrids.length > 0 && (
          <div className="mt-4">
            <h6>Active Grid Positions</h6>
            <Table striped bordered hover>
              <thead>
                <tr>
                  <th>Trading Pair</th>
                  <th>Upper Price</th>
                  <th>Lower Price</th>
                  <th>Grid Lines</th>
                  <th>Investment</th>
                  <th>Profit/Loss</th>
                </tr>
              </thead>
              <tbody>
                {activeGrids.map((grid, index) => (
                  <tr key={index}>
                    <td>{grid.tradingPair}</td>
                    <td>{formatCurrency(grid.upperPrice)}</td>
                    <td>{formatCurrency(grid.lowerPrice)}</td>
                    <td>{grid.gridLines}</td>
                    <td>{formatCurrency(grid.investment)}</td>
                    <td>{formatCurrency(grid.pnl)}</td>
                  </tr>
                ))}
              </tbody>
            </Table>
          </div>
        )}
      </Card.Body>
    </Card>
  );
};

export default GridTrading;
