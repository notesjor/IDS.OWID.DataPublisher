<template>
  <v-app>
    <v-app-bar app theme="dark" class="d-print-none" style="z-index:999">
      <div>
        <a :href="leftIconHref" target="_blank">
          <img alt="Logo" src="/logo_left.svg" style="min-height:40px; margin-left:10px" />
        </a>
      </div>

      <v-spacer></v-spacer>

      <div>
        <a :href="rightIconHref" target="_blank">
          <img alt="Logo" src="/logo_right.svg" style="min-height:70px" />
        </a>
      </div>
    </v-app-bar>
    <v-main>
      <v-navigation-drawer expand-on-hover rail>
        <nuxt-link to="/"><v-list-item prepend-icon="mdi-home" title="Startseite"></v-list-item></nuxt-link>

        <v-divider></v-divider>

        <v-list density="compact" nav>
          <nuxt-link to="/info"><v-list-item prepend-icon="mdi-book-open-page-variant" title="Spaltennamen"></v-list-item></nuxt-link>
        </v-list>

        <v-divider></v-divider>

        <v-list density="compact" nav>
          <nuxt-link to="/table"><v-list-item prepend-icon="mdi-table" title="Tabelle"></v-list-item></nuxt-link>
          <nuxt-link to="/pivot"><v-list-item prepend-icon="mdi-table-pivot"
              title="Pivot-Tabelle"></v-list-item></nuxt-link>
          <nuxt-link to="/download"><v-list-item prepend-icon="mdi-download" title="Download"></v-list-item></nuxt-link>
        </v-list>

        <v-divider></v-divider>

        <v-list density="compact" nav>
          <nuxt-link v-for="x in infos" :key="x._path" :to="x._path">
            <v-list-item :prepend-icon="x.icon" :title="x.title"></v-list-item>
          </nuxt-link>
        </v-list>

      </v-navigation-drawer>

      <v-container>
        <v-row>
          <v-col>
            <div>
              <h1 class="text-3xl font-bold">
                {{ appName }}
              </h1>
            </div>
          </v-col>
        </v-row>
        <slot />        
      </v-container>
    </v-main>

    <v-footer theme="dark" style="max-height:64px; z-index: 99999;">
      <v-card class="flex" flat tile>
        <v-card-text class="py-2" style="text-align:right">
          <div style="display:inline-block">
            {{ new Date().getFullYear() }} — <strong>{{ appName }}</strong>
          </div>
          <div style="display:inline-block">
            <a :href="footerContact" style="margin-left:15px" v-if="footerContact != null && footerContact.length > 1">{{
              $t("footer_Contact") }}</a>
            <a :href="footerImpressum" style="margin-left:15px"
              v-if="footerImpressum != null && footerImpressum.length > 1">{{ $t("footer_Impressum") }}</a>
            <a :href="footerDsgvo" style="margin-left:15px" v-if="footerDsgvo != null && footerDsgvo.length > 1">{{
              $t("footer_Dsgvo") }}</a>
          </div>
        </v-card-text>
      </v-card>
    </v-footer>
  </v-app>
</template>
  
<script>
export default {
  name: "Index",
  theme: { dark: false },
  data() {
    return {
      appName: null,
      appDescription: null,

      leftIconHref: null,
      rightIconHref: null,

      footerContact: null,
      footerImpressum: null,
      footerDsgvo: null,

      pages: [],
      infos: [],
    }
  },

  mounted() {
    this.appName = this.$config.public.appName;
    this.appDescription = this.$config.public.appDescription;

    this.leftIconHref = this.$config.public.leftIconHref;
    this.rightIconHref = this.$config.public.rightIconHref;

    this.footerContact = this.$config.public.footerContact;
    this.footerImpressum = this.$config.public.footerImpressum;
    this.footerDsgvo = this.$config.public.footerDsgvo;
  },
}
</script>
  
<style></style>