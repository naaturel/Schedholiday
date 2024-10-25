import { createRouter, createWebHistory } from 'vue-router';

import Connexion from './components/page/Connexion.vue';
import Contact from './components/page/Contact.vue';
import CreateActivity from './components/page/CreateActivity.vue';
import CreateHoliday from './components/page/CreateHoliday.vue';
import DetailHoliday from './components/page/DetailHoliday.vue';
import Error from './components/page/Error.vue';
import Home from './components/page/Home.vue';
import Register from './components/page/Register.vue';
import Deconnexion from './components/page/Deconnexion.vue';
import Profile from "@/components/page/Profile.vue";

const isProduction = process.env.NODE_ENV === 'production'

const routes = [
  
    { path: isProduction ? `/~e200017/dist/` : '/', name:"home", component: Home },
    { path: isProduction ? `/~e200017/dist/createActivity/:id` : `/createActivity/:id`, name:"createActivity", component: CreateActivity },
    { path: isProduction ? `/~e200017/dist/createHoliday` : `/createHoliday`, name:'createHoliday', component: CreateHoliday },
    { path: isProduction ? `/~e200017/dist/connexion` : `/connexion`, name:'connexion', component: Connexion },
    { path: isProduction ? `/~e200017/dist/contact` : `/contact`, name:'contact', component: Contact },
    { path: isProduction ? `/~e200017/dist/deconnexion` : `/deconnexion`, name:'deconnexion',component: Deconnexion},
    { path: isProduction ? `/~e200017/dist/detailHoliday/:id` : `/detailHoliday/:id`, name: "detailHoliday",  component: DetailHoliday },
    { path: isProduction ? `/~e200017/dist/error` : `/error`, name:'error',component: Error },
    { path: isProduction ? `/~e200017/dist/profile` : `/profile`, name:'profile',component: Profile },
    { path: isProduction ? `/~e200017/dist/register` : `/register`, name:'register',component: Register },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

export default router;