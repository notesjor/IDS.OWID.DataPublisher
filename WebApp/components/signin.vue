<template>
    <div v-if="isSignedIn">
        <div style="font-size: 11pt; padding-top: 5px; color: rgb(33, 150, 243);">
            <div>
                <v-icon style="margin-top: -3px;">mdi-information-outline</v-icon>
                <div style="display:inline; margin:0px 0px 0px 10px; font-weight: 600;">{{ $t('signin_access_granted') }}</div>
            </div>
            <div>
                {{$t('signin_access_granted_info_1')}}
                <strong style="display: inline-block;">{{ Username }}</strong> <span v-html="$t('signin_access_granted_info_2')"></span>
            </div>
        </div>
    </div>
    <div v-else
        style="display: grid; grid-template-columns: 220px auto; grid-template-rows: 100%; gap: 0px 0px; grid-template-areas: 'btn text';">
        <div style="grid-area: btn;">
            <v-btn prepend-icon="mdi-folder-key-outline" stacked color="rgb(33, 150, 243)" variant="outlined"
                style="text-transform: none;" @click="signIn">{{$t("signin_grant_access")}}</v-btn>
        </div>
        <div style="grid-area: text; font-size: 11pt; padding-top: 5px; color: rgb(33, 150, 243);">
            <div>
                <v-icon style="margin-top: -3px;">mdi-information-outline</v-icon>
                <div style="display:inline; margin:0px 0px 0px 10px; font-weight: 600;">{{ $t('signin_grant_access_status') }}</div>
            </div>
            <div v-html="$t('signin_grant_access_info')">
            </div>
        </div>
    </div>
</template>

<script>
import auth from "../korapJsClient/auth.js";
import userInfo from "../korapJsClient/userInfo.js";

export default {
    data() {
        return {
            Username: "",
            authentication: null,
            userInformation: null,
            isSignedIn: false,
        }
    },
    emits: ['signIn'],
    mounted() {
        var self = this;

        self.$data.authentication = new auth();
        self.$data.userInformation = new userInfo();

        self.$data.isSignedIn = self.$data.authentication.isSignedIn;
        if (self.$data.authentication.isSignedIn) {
            self.$data.userInformation.getUserInfo(self.$data.authentication.bearerToken, function (data) {
                self.$data.Username = data.username;
            });
            self.$emit('signIn', true);
        }
    },
    methods: {
        signIn() {
            var self = this;
            self.$data.authentication.signIn(auth => {
                self.$data.isSignedIn = auth;
                if (auth) {
                    window.location.reload()
                    self.$emit('signIn', true);
                }
            });
        },
    }
}
</script>

<style scoped>
.center {
    text-transform: none;
}
</style>