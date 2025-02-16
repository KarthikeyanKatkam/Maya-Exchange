const theme = {
    colors: {
        primary: '#007bff',
        secondary: '#6c757d',
        success: '#28a745',
        danger: '#dc3545',
        warning: '#ffc107',
        info: '#17a2b8',
        light: '#f8f9fa',
        dark: '#343a40',
    },
    fonts: {
        body: 'Arial, sans-serif',
        heading: 'Georgia, serif',
    },
    spacing: (factor: number) => `${0.25 * factor}rem`, // 1 unit = 0.25rem
};

export default theme;
