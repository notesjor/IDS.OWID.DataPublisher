<template>
    <div
        style="display: grid; grid-template-columns: 220px auto; grid-template-rows: 100%; gap: 0px 0px; grid-template-areas: 'btn text';">
        <div style="grid-area: btn;">
            <v-btn prepend-icon="mdi-folder-key-outline" stacked color="rgb(33, 150, 243)" variant="outlined"
                style="text-transform: none;">Datensatz freischalten</v-btn>
        </div>
        <div style="grid-area: text; font-size: 11pt; padding-top: 5px; color: rgb(33, 150, 243);">
            <div>
                <v-icon style="margin-top: -3px;">mdi-information-outline</v-icon>
                <div style="display:inline; margin:0px 0px 0px 10px; font-weight: 600;">Eingeschränkter Zugriff</div>
            </div>
            <div>
                Aktuell haben Sie Zugriff auf die öffentlich verfügbaren Daten.<br />Den gesamten Datensatz
                können Sie als Wissenschaftler*in, kostenfrei nach einer Anmeldung via KorAP freischalten.
            </div>
        </div>
    </div>
    <div>
        <div style="font-size: 11pt; padding-top: 5px; color: rgb(33, 150, 243);">
            <div>
                <v-icon style="margin-top: -3px;">mdi-information-outline</v-icon>
                <div style="display:inline; margin:0px 0px 0px 10px; font-weight: 600;">Vollständiger Zugriff</div>
            </div>
            <div>
                Mit ihrer Anmeldung als <strong>{{ Username }}</strong> haben Sie Zugriff auf den vollständigen Datensatz. Wenn Sie den Datensatz verwenden, zitieren Sie diesen bitte entsprechend.
                <br/> Bitte sehen Sie davon ab, den vollständigen Datensatz weiterzugeben (auch in veränderter Form) - verweisen Sie stattdessen auf diese Seite.
            </div>
        </div>
    </div>
</template>

<script>
import auth from '@/korapJsClient/auth.js';

export default {
    data() {
        return {
            Username: "test",
        }
    },
    mounted() {
        this.Username = "test"
    },
}
</script>

<style scoped>
.center {
    text-transform: none;
}</style>