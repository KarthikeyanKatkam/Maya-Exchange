##Directory structure:
└── karthikeyankatkam-maya-exchange/
    ├── README.md
    ├── SECURITY.md
    ├── package.json
    ├── state.md
    ├── analytics/
    │   ├── ai-tools/
    │   │   ├── market-prediction-model.py
    │   │   └── sentiment-analysis.py
    │   └── reports/
    │       ├── daily-report.md
    │       ├── user-activity-report.md
    │       └── weekly-report.md
    ├── backend/
    │   ├── Dockerfile
    │   ├── requirements.txt
    │   ├── protocols/
    │   │   ├── conversion/
    │   │   │   └── exchange_rate_service.py
    │   │   └── utils/
    │   │       ├── api_client.py
    │   │       └── env_config.py
    │   └── src/
    │       ├── __init__.py
    │       ├── main.py
    │       ├── utils.py
    │       ├── config/
    │       │   ├── config.py
    │       │   └── database.py
    │       ├── controllers/
    │       │   ├── dependencies.py
    │       │   ├── tradeController.py
    │       │   ├── transactionController.py
    │       │   └── userController.py
    │       ├── database/
    │       │   ├── __init__.py
    │       │   ├── config.py
    │       │   ├── migrations/
    │       │   │   ├── README.md
    │       │   │   ├── env.py
    │       │   │   └── script.py
    │       │   ├── models/
    │       │   │   ├── Transaction.py
    │       │   │   └── User.py
    │       │   └── queries/
    │       │       └── transaction_queries.py
    │       ├── models/
    │       │   ├── Trade.py
    │       │   ├── TradeHistory.py
    │       │   ├── Transaction.py
    │       │   ├── User.py
    │       │   ├── Wallet.py
    │       │   └── __init__.py
    │       ├── routers/
    │       │   ├── conversion_routes.py
    │       │   └── user_router.py
    │       ├── services/
    │       │   ├── CryptoService.py
    │       │   ├── KYCService.py
    │       │   ├── UPIService.py
    │       │   ├── exchange_service.py
    │       │   ├── trade_service.py
    │       │   └── user_service.py
    │       └── tests/
    │           ├── test_trade.py
    │           ├── test_transaction.py
    │           └── test_user.py
    ├── deployment/
    │   ├── aws/
    │   │   ├── ec2-setup.sh
    │   │   └── s3-setup.sh
    │   └── ci-cd/
    │       ├── build.sh
    │       └── pipeline.yml
    ├── documentation/
    │   ├── api/
    │   │   ├── api-endpoints.md
    │   │   └── authentication.md
    │   ├── developer/
    │   │   ├── contributing.md
    │   │   └── setup-guide.md
    │   └── frontend/
    │       ├── app-architecture.md
    │       ├── ui-components.md
    │       └── user-guide.md
    ├── frontend/
    │   ├── declarations.d.ts
    │   ├── package.json
    │   ├── assets/
    │   │   ├── styles.css
    │   │   ├── fonts/
    │   │   │   ├── Montserrat-Bold.ttf
    │   │   │   └── Roboto-Regular.ttf
    │   │   └── images/
    │   │       └── crypto-icons/
    │   ├── public/
    │   │   ├── index.html
    │   │   ├── manifest.json
    │   │   ├── robots.txt
    │   │   ├── styles.css
    │   │   └── icons/
    │   └── src/
    │       ├── images.d.ts
    │       ├── tsconfig.json
    │       ├── components/
    │       │   ├── CryptoCard.tsx
    │       │   ├── CryptoList.tsx
    │       │   ├── Dashboard.tsx
    │       │   ├── Footer.tsx
    │       │   ├── Header.tsx
    │       │   └── UserProfile.tsx
    │       ├── pages/
    │       │   ├── Dashboard.tsx
    │       │   ├── Home.tsx
    │       │   ├── Login.tsx
    │       │   ├── SignUp.tsx
    │       │   ├── Trade.tsx
    │       │   └── Wallet.tsx
    │       ├── redux/
    │       │   ├── actions.ts
    │       │   ├── reducers.ts
    │       │   └── store.ts
    │       └── utils/
    │           ├── api.ts
    │           ├── formatCurrency.ts
    │           └── validateForm.ts
    ├── infrastructure/
    │   ├── docker/
    │   │   ├── Dockerfile
    │   │   └── docker-compose.yml
    │   └── kubernetes/
    │       ├── deployment.yaml
    │       ├── ingress.yaml
    │       └── service.yaml
    ├── testing/
    │   ├── run_tests.sh
    │   ├── integration/
    │   │   ├── test_crypto_service.py
    │   │   ├── test_transaction_flow.py
    │   │   └── test_user_auth.py
    │   ├── load/
    │   │   ├── test_load_signups.py
    │   │   └── test_load_transactions.py
    │   └── unit/
    │       ├── test_transaction_model.py
    │       ├── test_upi_service.py
    │       └── test_user_model.py
    └── .github/
        └── workflows/
            ├── codeql.yml
            └── docker-image.yml##
