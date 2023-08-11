<template>
    <div>
        <v-row>
            <v-col>
                <div>
                    <h1 class="text-3xl font-bold underline">
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
        <v-row>
            <v-col>
                <h3 class="text-lg">Freier Download</h3>
                <p>Laden Sie die öffentlich zugänglichen Daten direkt herunter. Aus diesem Datensatz wurden alle
                    Informationen entfernt, die Rechte Dritter berühren oder berühren könnten (z. B. Lizenz- oder
                    Datenschutzrechte). </p>
                <br />
                <v-btn size="x-large" prepend-icon="mdi-download-outline" color="green-accent-4">Download</v-btn>
            </v-col>
            <v-col>
                <h3 class="text-lg">Erweiterter Download</h3>
                <p>Mit einer Authentifizierung via KorAP (kostenlose Nutzung für die akademische Forschung) können Sie den
                    vollständigen Datensatz herunterladen. Bitte beachten Sie evtl. beigelegte Lizenz- oder
                    Nutzungshinweise.</p>
                <br />
                <v-btn size="x-large" prepend-icon="mdi-lock" color="red-accent-4">Download</v-btn>
            </v-col>
        </v-row>
    </div>
</template>

<script>
export default {
    data() {
        return {
            appName: 'DataPublisher',
            appDescription: 'Copyright 2023 by IDS (Jan Oliver Rüdiger)'
        }
    },
    mounted() {
        this.appName = this.$config.public.appName;
        this.appDescription = this.$config.public.appDescription;
    },
}
</script>

<style lang="scss" scoped></style>