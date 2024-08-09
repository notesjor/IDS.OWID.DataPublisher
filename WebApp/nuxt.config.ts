import svgLoader from "vite-svg-loader"

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  ssr: false,
  modules: ['@pinia/nuxt', '@nuxtjs/i18n'],

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

  runtimeConfig: {
    public: {
      // The tool "IDS.OWID.DataPublisher.Tool.Prepper" generates the dataKey. Please use it here.
      dataKey: "DATA_KEY",

      appName: "Komposita mit Gatte und Gattin",

      leftIconHref: "https://www.owid.de/plus/index.html",
      rightIconHref: "https://www.ids-mannheim.de/",

      footerContact: "mailto:ruediger@ids-mannheim.de",
      footerImpressum: "https://www.owid.de/wb/owid/impressum.html",
      footerDsgvo: "https://www.owid.de/wb/owid/privacy.html",      

      citeText: "Ochs, Samira (2024): Komposita mit den relationalen Zweitgliedern *Gatte* und *Gattin* – eine korpusbasierte Studie aus genderlinguistischer Perspektive. Zeitschrift für Wortbildung / Journal of Word Formation",
      citeBibTeX: "@article{Ochs.2024,\r\n  author = {Ochs, Samira},\r\n  journal = {Zeitschrift für Wortbildung / Journal of Word Formation},\r\n  keywords = {Komposition Genderlinguistik Geschlecht Movierung Bedeutungsrelation Referenz Korpus},\r\n  number = 1,\r\n  pages = {},\r\n  title = {Komposita mit den relationalen Zweitgliedern Gatte und Gattin – eine korpusbasierte Studie aus genderlinguistischer Perspektive},\r\n  volume = 1,\r\n  year = 2024\r\n}",

      pivotProfiles: 
      [
        {
          "label": "Zweitglied_Form vs. Bedeutungsrelation",
          "query": [
            {
              "dataField": "c07",
              "area": "column"
            },
            {
              "dataField": "c11",
              "area": "row"
            },
            {
              "dataField": "c01",
              "area": "data",
              "summaryType": "count",
              "dataType": "number"
            }
          ]
        },
        {
          "label": "Erstglied_Form vs. Erstglied_Ref_Gender",
          "query": [
            {
              "dataField": "c03",
              "area": "column"
            },
            {
              "dataField": "c05",
              "area": "row"
            },
            {
              "dataField": "c01",
              "area": "data",
              "summaryType": "count",
              "dataType": "number"
            }
          ]
        },
        {
          "label": "Genusgleichheit_Kompositumsglieder vs. Bedeutungsrelation",
          "query": [
            {
              "dataField": "c14",
              "area": "column"
            },
            {
              "dataField": "c11",
              "area": "row"
            },
            {
              "dataField": "c01",
              "area": "data",
              "summaryType": "count",
              "dataType": "number"
            }
          ]
        },
        {
          "label": "Land und Medium vs. Jahr",
          "query": [
            {
              "dataField": "c19",
              "area": "column"
            },
            {
              "dataField": "c17",
              "area": "column"
            },
            {
              "dataField": "c18",
              "area": "row"
            },
            {
              "dataField": "c01",
              "area": "data",
              "summaryType": "count",
              "dataType": "number"
            }
          ]
        }
      ],

      appURL: "https://www.owid.de/plus/gattin2023" // muss an app.baseURL angeglichen werden
    },    
  },

  app: {
    baseURL: "/plus/gattin2023" // muss an runtimeConfig.appURL angeglichen werden
  },

  compatibilityDate: "2024-08-09"
})