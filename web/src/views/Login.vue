<template>
    <v-container class="fill-height">
        <v-row align="center" justify="center" no-gutters>
            <v-col cols="12" sm="5">
                <v-card
                class="mx-auto"
                max-width="auto"
                outlined>
                    <v-card-text>
                        <v-card-title class="blue--text darken-1--text">
                            ĐĂNG NHẬP
                        </v-card-title>
                        
                        <v-card-subtitle  class="blue--text darken-1--text">
                            Chương trình tính thù lao Fiber
                        </v-card-subtitle>
                         <v-row align="center" justify="center" no-gutters>
                            <v-col cols="12" sm="10">
                            <v-form
                            ref="loginForm"
                            v-model="loginValid"
                            lazy-validation
                            >
                                <v-text-field
                                outlined
                                dense
                                v-model="username"
                                :rules="textRules"
                                label="Người dùng"
                                
                                required
                                ></v-text-field>
                                <v-text-field
                                outlined
                                dense
                                v-model="password"
                                :rules="textRules"
                                :type="'password'"
                                label="Mật khẩu"
                                required
                                ></v-text-field>
                                <v-row align="center" justify="center" no-gutters>
                                    <v-btn
                                    color="primary"
                                    depressed
                                    @click="login()"
                                    :disabled="!loginValid"
                                    >
                                    Đăng nhập
                                    </v-btn>
                                </v-row>
                            </v-form>
                            </v-col>
                         </v-row>
                    </v-card-text>
                
                </v-card>
            </v-col>
        </v-row>
        <v-row>
            <v-snackbar
                v-model="snackbar"
                >
                {{ text }}
                <template v-slot:action="{ attrs }">
                    <v-btn
                    color="primary"
                    text
                    v-bind="attrs"
                    @click="snackbar = false"
                    >
                    Đóng
                    </v-btn>
                </template>
            </v-snackbar>
        </v-row>
    </v-container>
</template>

<script>

import factory from "../server/factory/factory";
import common from '@/server/common/common.js';
const auth = factory.get("auth");
export default {
    data() {
        return {
            //Đăng nhập

            loginValid:false,
            username:null,
            password:null,
            textRules: [
                v => !!v || 'Không được bỏ trống',
            ],

            //snapbar

            snackbar: false,
            text: null,
            
        }
    },
    methods: {
       

        
        //Đăng nhập
        login() {
            var validate = this.$refs.loginForm.validate();
            if(validate)
            {
                var self=this;
                var user={ma_ND:self.username, Matkhau:self.password};
                auth.auth(user).then(response=>{
                    if(response.data.success){
                        var value = {
                            ma_ND: response.data.data.nguoidung.ma_ND,
                            ten_NV: response.data.data.nguoidung.ten_NV,
                            token: response.data.data.token.access_token,
                            quyen_ID: response.data.data.quyen.quyen_id
                        };
                        var today = new Date();
                        var nexthour = new Date();
                        nexthour.setDate(today.getDate() + response.data.data.token.expires_in/86400);
                        document.cookie = "token_session=" + JSON.stringify(value) + ";expires =" +nexthour +"";
                        self.text="Đăng nhập thành công";
                        self.snackbar=true;
                        self.$router.push("/home");
                        
                    }else{
                        self.text=response.data.message;
                        self.snackbar=true;
                    }
                })
            }
        }
    },

}
</script>

<style>

</style>