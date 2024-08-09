<template>
    <div>
        <v-row>
            <v-col>
                <Signin @signIn="signIn" />
            </v-col>
        </v-row>
        <v-row>
            <v-col>
                <v-card>
                    <v-card-title>{{ $t('download_public_data') }}</v-card-title>
                    <v-card-text>
                        <p>{{ $t('download_public_data_info') }}</p>
                    </v-card-text>
                    <v-card-actions>
                        <v-btn size="x-large" prepend-icon="mdi-download-outline" color="green-accent-4"
                            @click="download_public">
                            {{ $t('download') }}
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-col>
            <v-col>
                <v-card :disabled="blockDownload">
                    <v-card-title>{{ $t('download_restricted_data') }}</v-card-title>
                    <v-card-text>
                        <p>{{ $t('download_restricted_data_info') }}</p>
                    </v-card-text>
                    <v-card-actions>
                        <v-btn size="x-large" :prepend-icon="blockDownload ? 'mdi-lock' : 'mdi-download-outline'"
                            color="red-accent-4" @click="download_secure">
                            {{ $t('download') }}
                        </v-btn>
                    </v-card-actions>
                </v-card>
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
import Signin from '@/components/signin.vue';
import Cite from '@/components/cite.vue'

export default {
    components: {
        Signin,
        Cite,
    },
    data() {
        return {
            blockDownload: true,
        }
    },
    mounted() {

    },
    methods: {
        signIn() {
            var self = this;
            self.$data.blockDownload = false;
        },
        download_public() {
            window.open(`${this.$config.public.appURL}/data.zip`, '_self');
        },
        download_secure() {
            window.open(`${this.$config.public.appURL}/${this.$config.public.dataKey}/data.zip`, '_self');
        }
    }
}
</script>

<style lang="scss" scoped></style>