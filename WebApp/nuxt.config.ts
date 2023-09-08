import svgLoader from "vite-svg-loader"

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  ssr: false,
  postcss: {
    plugins: {
      tailwindcss: {},
      autoprefixer: {},
    },
  },
  css: [
    'vuetify/lib/styles/main.sass',
    '@mdi/font/css/materialdesignicons.min.css',
    '~/assets/css/main.css'
  ],
  build: {
    transpile: ['vuetify'],
  },
  vite: {
    define: {
      'process.env.DEBUG': false,
    },
    plugins: [svgLoader({
      defaultImport: 'url',
    })],
  },
  modules: ['@pinia/nuxt', '@nuxt/content'],  
  runtimeConfig: {
    public: {
      // The tool "IDS.OWID.DataPublisher.Tool.Prepper" generates the dataKey. Please use it here.
      dataKey: "BAB34D77121580AF397F9D04AE4F0EB0",

      appName: "Empirische Genderlinguistik: Komposita mit Gatte und Gattin",

      leftIconHref: "https://www.owid.de/plus/index.html",
      rightIconHref: "https://www.ids-mannheim.de/",

      footerContact: "mailto:ruediger@ids-mannheim.de",
      footerImpressum: "https://www.owid.de/wb/owid/impressum.html",
      footerDsgvo: "https://www.owid.de/wb/owid/privacy.html",      

      citeText: "Carolin Müller-Spitzer und Jan Oliver Rüdiger (2022): The influence of the corpus on the representation of gender stereotypes in the dictionary. A case study of corpus-based dictionaries of german. In: XX EURALEX Proceedings.",
      citeBibTeX: "@article{Kohler.2005,\r\n  added-at = {2013-04-27T20:43:19.000+0200},\r\n  author = {K{\"o}hler, Reinhard},\r\n  biburl = {https://www.bibsonomy.org/bibtex/2022b9f8fcbe0a93dfc552648499a9600/},\r\n  interhash = {c308e63d490b0860aa7a18e13ac09e2e},\r\n  intrahash = {022b9f8fcbe0a93dfc552648499a9600},\r\n  journal = {GLDV-Journal for Computational Linguistics and Language Technology},\r\n  keywords = {KI Korpuslinguistik},\r\n  number = 2,\r\n  pages = {1--16},\r\n  timestamp = {2013-04-27T21:03:58.000+0200},\r\n  title = {Korpuslinguistik - zu wissenschaftstheoretischen Grundlagen und methodologischen Perspektiven},\r\n  volume = 20,\r\n  year = 2005\r\n}",

      pivotProfiles: 
      [{"label":"A/B-Vergleich: Linguistische Klasse","query":[{"dataField":"c07","area":"column"},{"dataField":"c08","area":"row"},{"dataField":"c00","area":"data","summaryType":"count"}]},{"label":"A/B-Vergleich: Generisches Maskulinum","query":[{"dataField":"c31","area":"column"},{"dataField":"c32","area":"row"},{"dataField":"c00","area":"data","summaryType":"count"}]},{"label":"A/B-Vergleich: Konkrete Referenz","query":[{"dataField":"c39","area":"column"},{"dataField":"c40","area":"row"},{"dataField":"c00","area":"data","summaryType":"count"}]}]
    }
  },
  app: {
    baseURL: "/"
  }
})
