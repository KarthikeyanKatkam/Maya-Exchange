import '@testing-library/jest-dom/extend-expect'; // for additional matchers

// Mocking global fetch for API calls in tests
global.fetch = jest.fn(() =>
  Promise.resolve({
    ok: true, // Indicates the response was successful
    status: 200, // HTTP status code
    statusText: 'OK', // Status text
    headers: {
      get: () => null, // Mock headers if needed
    },
    json: () => Promise.resolve({}), // Your mock JSON response
    text: () => Promise.resolve(''), // Optional: mock text response
    redirected: false, // Required property
    type: 'basic', // Required property
    url: '', // Required property
    clone: () => new Response(), // Required method
  } as unknown as Response) // Cast to unknown first, then to Response
);

// Setting up a mock for local storage
const mockLocalStorage = (() => {
  let store: { [key: string]: string } = {};
  return {
    getItem: (key: string) => store[key] || null,
    setItem: (key: string, value: string) => {
      store[key] = value.toString();
    },
    removeItem: (key: string) => {
      delete store[key];
    },
    clear: () => {
      store = {};
    },
  };
})();

Object.defineProperty(window, 'localStorage', {
  value: mockLocalStorage,
});
