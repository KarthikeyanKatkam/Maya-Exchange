from textblob import TextBlob
import pandas as pd
import requests
from bs4 import BeautifulSoup

# Function to fetch cryptocurrency news articles (Example: using a public API or web scraping)
def fetch_news():
    url = "https://cryptonews.com/news/"
    response = requests.get(url)
    soup = BeautifulSoup(response.text, 'html.parser')
    
    articles = []
    for article in soup.find_all('div', class_='news-item'):
        title = article.find('a').text.strip()
        link = article.find('a')['href']
        articles.append({'title': title, 'link': link})
    
    return pd.DataFrame(articles)

# Perform sentiment analysis on the fetched news titles
def analyze_sentiment(news_data):
    news_data['polarity'] = news_data['title'].apply(lambda title: TextBlob(title).sentiment.polarity)
    news_data['sentiment'] = news_data['polarity'].apply(lambda p: 'positive' if p > 0 else ('negative' if p < 0 else 'neutral'))
    return news_data

# Main execution
if __name__ == "__main__":
    print("Fetching cryptocurrency news...")
    news_data = fetch_news()
    
    print("Analyzing sentiment of the news...")
    sentiment_data = analyze_sentiment(news_data)
    
    print("Sentiment analysis results:")
    print(sentiment_data)

    # Save the sentiment results to a CSV (optional)
    sentiment_data.to_csv("cryptocurrency_news_sentiment.csv", index=False)
