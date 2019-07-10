import Vue from "vue";
import Router from "vue-router";
import routes from "./routers";
import store from "@/store";
import iView from "iview";
import {
  setToken,
  getToken,
  canTurnTo,
  setTitle
} from "@/libs/util";
import {
  getUnion
} from '@/libs/tools'
import staticRouters from '@/router/static-routers'
import axios from '@/libs/api.request'
import config from "@/config";
// 引入加载菜单
import { formatMenu } from '@/libs/router-util'

const {
  homeName
} = config;
const baseUrl =
  process.env.NODE_ENV === "development" ?
    config.baseUrl.dev :
    config.baseUrl.pro;

Vue.use(Router);
const router = new Router({
  routes: [...routes],
  mode: "hash"
});
const LOGIN_PAGE_NAME = "login";

const initRouter = () => {
  let list = []
  axios.request({
    url: 'account/menu',
    method: 'get'
  }).then(res => {
    var menuData = res.data;
    // 格式化菜单
    list = formatMenu(menuData)
    // 刷新界面菜单
    store.dispatch('refreshMenuList', list)

  });

  return list
}

const turnTo = (to, checkPermission, permissions, next) => {
  // if (canTurnTo(to.name, access, routes)) next();
  // // 有权限，可访问
  // else
  //   next({
  //     replace: true,
  //     name: "error_401"
  //   }); // 无权限，重定向到401页面

  // 有权限，可访问
  to.meta.checkPermission = checkPermission;
  permissions = permissions || [];
  if (permissions && permissions[to.name]) {
    to.meta.permissions = permissions[to.name];
  }
  next();
};

router.beforeEach((to, from, next) => {
  if (!to.matched || to.matched.length <= 0) {
    if (store.state.user.hasGetInfo) {
      store.dispatch("closeTag", to.name);
      next({ path: "/404", replace: true });
    }
  }

  iView.LoadingBar.start();
  const token = getToken();
  if (!token && to.name !== LOGIN_PAGE_NAME) {
    // 未登录且要跳转的页面不是登录页
    next({
      name: LOGIN_PAGE_NAME // 跳转到登录页
    });
  } else if (!token && to.name === LOGIN_PAGE_NAME) {
    // 未登陆且要跳转的页面是登录页
    next(); // 跳转
  } else if (token && to.name === LOGIN_PAGE_NAME) {
    // 已登录且要跳转的页面是登录页
    next({
      name: homeName // 跳转到homeName页
    });
  } else {
    let checkPermission = true;
    if (store.state.user.hasGetInfo) {
      checkPermission = store.state.user.user_type != 0;
      next()
      turnTo(to, checkPermission, store.state.user.permissions, next)
    } else {
      store.dispatch('getUserInfo').then(user => {
        // 拉取用户信息，通过用户权限和跳转的页面的name来判断是否有权限访问;access必须是一个数组，如：['super_admin']
        checkPermission = user.user_type != 0;
        initRouter();
        //next()
        turnTo(to, checkPermission, user.permissions, next)
      }).catch(() => {
        setToken('')
        next({
          name: 'login'
        })
      })
    }
  }
});

router.afterEach(to => {
  setTitle(to, router.app);
  iView.LoadingBar.finish();
  window.scrollTo(0, 0);
});

export default router;

const createRouter = () => new Router({
  mode: 'hash',
  routes: [...routes]
})

export function resetRouter() {
  const newRouter = createRouter()
  router.matcher = newRouter.matcher
}
