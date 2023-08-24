import svgLoader from "vite-svg-loader"

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
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
  modules: ['@pinia/nuxt'],  
  runtimeConfig: {
    public: {
      // ToDo: You need to create a directory with the name in "public" and drop a ZIP-File "download.zip" in it
      privatePackageName: "XAZ89_65",

      appName: "Empirische Genderlinguistik: Komposita mit Gatte und Gattin",
      appDescription: "In der Studie werden Komposita mit den relationalen Zweitgliedern Gatte und Gattin aus genderlinguistischer Perspektive untersucht. Obwohl solche Wortbildungen Zugang zu impliziten Versprachlichungen von Geschlechterrelationen bieten, wurden sie in der Genderlinguistik bisher kaum beachtet. Umgekehrt spielen Genus/Sexus in der Kompositumsforschung bisher keine Rolle. Die Untersuchung basiert auf empirischen Analysen von Korpusmaterial aus dem elexiko Korpus. Drei neue Befunde lassen sich ableiten: 1) Das Zweitglied ist ausschlaggebend für die Bedeutungsrelation (Gattin = possessiv; Gatte = qualifizierend); 2) Genusgleichheit bzw. -divergenz der Konstituenten sind ausschlaggebend für die Kompositumsbedeutung; 3) Movierte Erstglieder sind die häufigste Form zur Referenz auf spezifische weibliche Einzelpersonen. Bei weiblichen Referentinnen herrscht insgesamt aber eine große Formenvariation – im Gegensatz zu männlichen Referenten, die fast ausschließlich mit maskulinen Erstgliedern versprachlicht werden.",
      appKeywords: ["Komposition", "Genderlinguistik", "Geschlecht", "Movierung", "Bedeutungsrelation", "Referenz", "Korpus"],

      leftIconHref: "https://www.owid.de/plus/index.html",
      rightIconHref: "https://www.ids-mannheim.de/",

      footerContact: "mailto:ruediger@ids-mannheim.de",
      footerImpressum: "https://www.owid.de/wb/owid/impressum.html",
      footerDsgvo: "https://www.owid.de/wb/owid/privacy.html",      

      citeText: "Carolin Müller-Spitzer und Jan Oliver Rüdiger (2022): The influence of the corpus on the representation of gender stereotypes in the dictionary. A case study of corpus-based dictionaries of german. In: XX EURALEX Proceedings.",
      citeBibTeX: "@article{Kohler.2005,\r\n  added-at = {2013-04-27T20:43:19.000+0200},\r\n  author = {K{\"o}hler, Reinhard},\r\n  biburl = {https://www.bibsonomy.org/bibtex/2022b9f8fcbe0a93dfc552648499a9600/},\r\n  interhash = {c308e63d490b0860aa7a18e13ac09e2e},\r\n  intrahash = {022b9f8fcbe0a93dfc552648499a9600},\r\n  journal = {GLDV-Journal for Computational Linguistics and Language Technology},\r\n  keywords = {KI Korpuslinguistik},\r\n  number = 2,\r\n  pages = {1--16},\r\n  timestamp = {2013-04-27T21:03:58.000+0200},\r\n  title = {Korpuslinguistik - zu wissenschaftstheoretischen Grundlagen und methodologischen Perspektiven},\r\n  volume = 20,\r\n  year = 2005\r\n}"
    }
  },
  app: {
    baseURL: "/"
  }
})
