import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
// import locale from 'element-ui/lib/locale/lang/en';
import 'element-ui/lib/theme-chalk/reset.css';
import locale from 'element-ui/lib/locale/lang/vi';
import JsonExcel from "vue-json-excel";
import excel from 'vue-excel-export'

Vue.use(ElementUI, { locale });
Vue.config.productionTip = false;
Vue.component("downloadExcel", JsonExcel);
Vue.use(excel)

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
