<template>
    <div>
        <v-row>
            <v-col>
                <div>
                    <h1 class="text-3xl font-bold">
                        {{ appName }}
                    </h1>
                </div>
            </v-col>
        </v-row>
        <v-row>
            <v-col>
                <div v-html="appDescription">
                </div>
            </v-col>
        </v-row>
        <v-row v-if="appKeywords != undefined && appKeywords != null && appKeywords.length > 0">
            <v-col>
                <div>
                    <h2 class="text-xl font-bold" style="margin-bottom: 10px;">
                        Keywords:
                    </h2>
                    <v-chip v-for="k in appKeywords" :key="k" style="margin-right:10px">{{ k }}</v-chip>
                </div>
            </v-col>
        </v-row>
        <v-row>
            <v-col>
                <br>
                <hr />
            </v-col>
        </v-row>
        <v-row>
            <v-col>
                <Cite />
            </v-col>
        </v-row>
    </div>
</template>

<script>
import Cite from '@/components/cite.vue'

export default {
    components: {
        Cite
    },
    data() {
        return {
            appName: 'DataPublisher',
            appDescription: 'Copyright 2023 by IDS (Jan Oliver Rüdiger)',
            appKeywords: [],
        }
    },
    mounted() {
        this.appName = this.$config.public.appName;
        this.appDescription = this.$config.public.appDescription;
        this.appKeywords = this.$config.public.appKeywords;
    },
}
</script>

<style lang="scss" scoped></style>