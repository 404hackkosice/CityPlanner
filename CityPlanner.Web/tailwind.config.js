module.exports = {
  content: ["./**/*.{razor,html,cshtml}"],
  theme: {
    screens: {
        xxs: '340px',
        xs: '410px',
        sm: '480px',
        s: '590px',
        md: '720px',
        m: '840px',
        lg: '976px',
        l: '1200px',
        xl: '1440px'
    },
    extend: {
      keyframes: {
        slideIn: {
          '0%': { transform: 'translateY(0%)' },
          '100%': { transform: 'translateY(100%)' },
        },
        slideOut: {
          '0%': { transform: 'translateY(0%)' },
          '100%': { transform: 'translateY(-100%)' },
        },
      },
      animation: {
        slideIn: 'slideIn 1s ease-in-out',
        slideOut: 'slideOut 1s ease-in-out',
      },
      colors: {
          pageBg: 'hsl(0, 0%, 96%)',
          main: 'hsl(230, 52%, 53%)',
          mainDark: 'hsl(229, 61%, 29%)',
          mainLight: 'hsl(228, 68%, 79%)',
          subText: 'hsl(222, 35%, 51%)'
      }
    },
  },
  plugins: [],
}