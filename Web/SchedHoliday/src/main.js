import './assets/main.css'

import { createApp } from 'vue'
import vue3GoogleLogin from "vue3-google-login"
import App from './App.vue'
import router from './router.js'
import store from './store/store.js'

const app = createApp(App)
const GOOGLE_CLIENT_ID = "119426613228-sn8bcmsnlultncd2df12eljubof50icg.apps.googleusercontent.com"

app.use(router)
app.use(store)
app.use(vue3GoogleLogin ,{
    clientId : GOOGLE_CLIENT_ID
})
app.mount('#app')
