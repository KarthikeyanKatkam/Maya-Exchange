using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.SQS;
using Amazon.SimpleEmail;
using Amazon.CognitoIdentityProvider;
using Amazon.DynamoDB;
using Amazon.Lambda;
using Microsoft.Extensions.Configuration;

namespace Maya.Exchange.Config
{
    public class AwsConfig
    {
        private readonly IConfiguration _configuration;
        
        public AwsConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AWSCredentials GetAwsCredentials()
        {
            return new BasicAWSCredentials(
                _configuration["AWS:AccessKey"],
                _configuration["AWS:SecretKey"]
            );
        }

        public AmazonS3Client GetS3Client()
        {
            var credentials = GetAwsCredentials();
            return new AmazonS3Client(credentials, RegionEndpoint.GetBySystemName(_configuration["AWS:Region"]));
        }

        public AmazonSQSClient GetSqsClient() 
        {
            var credentials = GetAwsCredentials();
            return new AmazonSQSClient(credentials, RegionEndpoint.GetBySystemName(_configuration["AWS:Region"]));
        }

        public AmazonSimpleEmailServiceClient GetSesClient()
        {
            var credentials = GetAwsCredentials();
            return new AmazonSimpleEmailServiceClient(credentials, RegionEndpoint.GetBySystemName(_configuration["AWS:Region"]));
        }

        public AmazonCognitoIdentityProviderClient GetCognitoClient()
        {
            var credentials = GetAwsCredentials();
            return new AmazonCognitoIdentityProviderClient(credentials, RegionEndpoint.GetBySystemName(_configuration["AWS:Region"]));
        }

        public AmazonDynamoDBClient GetDynamoDbClient()
        {
            var credentials = GetAwsCredentials();
            return new AmazonDynamoDBClient(credentials, RegionEndpoint.GetBySystemName(_configuration["AWS:Region"]));
        }

        public AmazonLambdaClient GetLambdaClient()
        {
            var credentials = GetAwsCredentials();
            return new AmazonLambdaClient(credentials, RegionEndpoint.GetBySystemName(_configuration["AWS:Region"]));
        }

        // S3 Configuration
        public string GetBucketName()
        {
            return _configuration["AWS:BucketName"];
        }

        public string GetKycDocumentsBucket()
        {
            return _configuration["AWS:KycDocumentsBucket"];
        }

        // SQS Configuration
        public string GetTransactionQueueUrl()
        {
            return _configuration["AWS:TransactionQueueUrl"];
        }

        public string GetNotificationQueueUrl() 
        {
            return _configuration["AWS:NotificationQueueUrl"];
        }

        // Cognito Configuration
        public string GetUserPoolId()
        {
            return _configuration["AWS:UserPoolId"];
        }

        public string GetClientId()
        {
            return _configuration["AWS:ClientId"];
        }

        // DynamoDB Configuration
        public string GetTransactionTableName()
        {
            return _configuration["AWS:TransactionTableName"];
        }

        public string GetUserTableName()
        {
            return _configuration["AWS:UserTableName"];
        }

        // Lambda Configuration
        public string GetKycVerificationFunction()
        {
            return _configuration["AWS:KycVerificationFunction"];
        }

        public string GetCurrencyConversionFunction()
        {
            return _configuration["AWS:CurrencyConversionFunction"];
        }
    }
}

