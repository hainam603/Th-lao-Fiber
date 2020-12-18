import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Login from '@/views/Login.vue'
import common from '@/server/common/common.js';
import PageNotFound from '@/views/PageNotFound.vue';
import Logout from '@/views/Logout.vue';
import New from '@/views/New.vue';
import CreateNew from '@/views/CreateNew.vue';
// import Fee1 from '@/views/Fee1.vue';
// import Fee2 from '@/views/Fee2.vue';


Vue.use(VueRouter)

const routes = [

  {
    path: '/login',
    name: 'Login',
    component: Login,
    meta: { allowAnonymous: true, title: "Đăng nhập" },
  },
  {
    path: '/logout',
    name: 'Logout',
    component: Logout,
    meta: { allowAnonymous: true, title: "Đăng xuất" },
  },
  {
    path: '/home',
    name: 'Home',
    component: Home,
    meta: { requiresAuth: true, title: "Trang chủ" },
  },
  {
    path: '/new',
    name: 'New',
    component: New,
    meta: { requiresAuth: true, title: "Phát triển mới fiber" },
  },
  {
    path: '/createnew',
    name: 'CreateNew',
    component: CreateNew,
    meta: { requiresAuth: true, title: "Tạo danh sách phát triển mới fiber" },
  },
  // {
  //   path: '/fee1',
  //   name: 'Fee1',
  //   component: Fee1,
  //   meta: { requiresAuth: true, title: "Thù lao đợt 1" },
  // },
  // {
  //   path: '/fee2',
  //   name: 'Fee2',
  //   component: Fee2,
  //   meta: { requiresAuth: true, title: "Thù lao đợt 2" },
  // },
  
];


const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

var UserLogin = common.GetInfoUserLogin('token_session');
// if(UserLogin.token)
//     console.log(UserLogin);

router.beforeEach((to, from, next) => {
  if (to.matched.some((record) => record.meta.requiresAuth)) {
    if(!UserLogin.token)
      next('/login');
    else{
          next();
      }
  } else next();

  if (to.meta.title) 
    document.title = to.meta.title;
});

export default router
