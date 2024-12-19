#!/bin/bash

# Ensure AWS CLI is installed
if ! command -v aws &> /dev/null
then
    echo "AWS CLI not found. Installing..."
    sudo apt-get install -y awscli
fi

# Set AWS CLI configuration (replace with your credentials)
aws configure set aws_access_key_id YOUR_AWS_ACCESS_KEY
aws configure set aws_secret_access_key YOUR_AWS_SECRET_KEY
aws configure set default.region us-east-1

# Create an S3 bucket
echo "Creating S3 bucket..."
BUCKET_NAME="maya-exchange-assets-$(date +%s)"
aws s3 mb s3://$BUCKET_NAME

# Set up bucket policy to allow public read access (for static assets like images)
echo "Setting up bucket policy..."
cat <<EOF > bucket-policy.json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Sid": "PublicReadGetObject",
      "Effect": "Allow",
      "Principal": "*",
      "Action": "s3:GetObject",
      "Resource": "arn:aws:s3:::$BUCKET_NAME/*"
    }
  ]
}
EOF

aws s3api put-bucket-policy --bucket $BUCKET_NAME --policy file://bucket-policy.json

# Upload files to S3 bucket (replace with your actual file paths)
echo "Uploading assets to S3..."
aws s3 cp /path/to/your/static/assets s3://$BUCKET_NAME/ --recursive

echo "S3 setup completed successfully! Your bucket is: s3://$BUCKET_NAME"
