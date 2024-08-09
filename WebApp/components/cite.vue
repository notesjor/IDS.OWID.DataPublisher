<template>
    <div>        
        <v-row>
            <v-col>
                <div class="v-card-title">Zitation</div>
            </v-col>
        </v-row>
        <v-row>
            <div class="v-card-text" style="margin:-20px 0px 0px 10px">{{ $t('cite_text') }}</div>
        </v-row>
        <v-row>
            <v-col>
                <div style="color:darkgray; margin: -10px 40px 10px 30px; font-weight: 500;">    
                    {{ citeText }}                
                </div>
            </v-col>
        </v-row>
        <v-row>
            <div class="v-card-text" style="margin:-20px 0px 0px 10px">{{ $t('cite_bibtex') }}</div>
        </v-row>
        <v-row>
            <v-col>
                <pre style="color:darkgray; margin: -10px 40px 10px 30px;">
{{ citeBibTeX }}
                </pre>
            </v-col>
        </v-row>
    </div>
</template>

<script>
export default {
    name: "Cite",
    data() {
        return {
        }
    },
    mounted() {    },
    computed: {
        citeText() {
            return this.$config.public.citeText;
        },    
        citeBibTeX() {
            return this.$config.public.citeBibTeX;
        },    
    },
}
</script>

<style lang="scss" scoped>

</style>