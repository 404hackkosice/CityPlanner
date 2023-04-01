module.exports = {
  content: ["./**/*.{razor,html,cshtml}"],
  theme: {
    extend: {
      fontFamily: {
        'sans': ['Montserrat'],
      }
    },
  },
  plugins: [
    require("tailwindcss-animate")
  ],
}