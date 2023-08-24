<template>
    <v-tooltip>
        <template v-slot:activator="{ props }">
            <v-icon style="font-size:9pt; margin-top: -10px;" v-bind="props">mdi-information-outline</v-icon>
        </template>
        <v-tooltip-text>
            <div v-html="tip"></div>
        </v-tooltip-text>
    </v-tooltip>
</template>

<script>
export default {
    props: {
        tip: String
    }
}
</script>

<style lang="scss" scoped></style>