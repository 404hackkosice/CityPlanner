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
        typing: {
          "0%": {
            width: "0%",
            visibility: "hidden"
          },
          "100%": {
            width: "100%"
          }  
        },
        blink: {
          "50%": {
            borderColor: "sky-100"
          },
          "100%": {
            borderColor: "sky-600"
          }  
        }
      },
      animation: {
        typing: "typing 2s steps(13) infinite alternate, blink .7s infinite"
      },
      colors: {
          pageBg: 'hsl(0, 0%, 96%)',
          main: 'hsl(230, 52%, 53%)',
          mainDark: 'hsl(229, 61%, 29%)',
          mainLight: 'hsl(228, 68%, 79%)',
          subText: 'hsl(222, 35%, 51%)',
          subTextLight: 'hsl(230, 72%, 65%)'
      }
    },
  },
  plugins: [
    require("tailwindcss-animate")
  ],
}