// api.ts
const API_URL = 'https://api.maya-exchange.com'; // Replace with your actual API base URL

// Generic API request handler
const apiRequest = async (url: string, method: string = 'GET', body: any = null) => {
  try {
    const headers: any = {
      'Content-Type': 'application/json',
    };

    let options: RequestInit = {
      method,
      headers,
    };

    if (body) {
      options.body = JSON.stringify(body);
    }

    const response = await fetch(`${API_URL}${url}`, options);

    if (!response.ok) {
      throw new Error(`API request failed with status ${response.status}`);
    }

    return await response.json();
  } catch (error) {
    console.error('API Error:', error);
    throw error;
  }
};

// Example API functions
export const getUser = (userId: string) => apiRequest(`/users/${userId}`);

export const updateUser = (userId: string, userData: object) =>
  apiRequest(`/users/${userId}`, 'PUT', userData);

export const getBalance = (userId: string) => apiRequest(`/wallet/${userId}/balance`);

export const getTradeHistory = (userId: string) =>
  apiRequest(`/trades/${userId}/history`);
