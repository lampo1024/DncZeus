import { getToken, hasChild, localSave, localRead } from '@/libs/util'
import Main from '@/components/main'
import parentView from '@/components/parent-view'
// import axios from 'axios'
import axios from '@/libs/api.request'
import config from '@/config'
import { forEach } from '@/libs/tools'
const baseUrl = process.env.NODE_ENV === 'development' ? config.baseUrl.dev : config.baseUrl.pro

// 初始化路由
export const initRouter = (vm) => {
  // if (!getToken()) {
  //   return
  // }
  let list = []
  // 模拟异步请求，改为您实际的后端请求路径
  // axios.get(baseUrl + 'system/permission/userMenuList', {
  //   headers: { 'Authorization': 'Bearer ' + getToken() }
  // })

  axios.request({
    url: 'account/menu',
    method: 'get'
  }).then(res => {
    var menuData = res.data
    // 格式化菜单
    list = formatMenu(menuData)
    // 刷新界面菜单
    //vm.$store.commit('setMenuList', list)
    vm.$store.commit('refreshMenuList', list)
  });

  return list
}

// 加载菜单，在创建路由时使用
export const loadMenu = () => {
  let list = []
  axios.request({
    url: 'account/menu',
    method: 'get'
  }).then(res => {
    var menuData = res.data
    // 这是后端回传给前端的数据，如上面所说的
    // 格式化菜单
    list = formatMenu(menuData)
  });

  return list
}

// 格式化菜单
export const formatMenu = (list) => {
  let res = []
  forEach(list, item => {
    let obj = {
      path: item.path,
      name: item.name,
      icon: (item.meta && item.meta.icon) || ''
    }
    obj.meta = item.meta
    //obj.meta.showAlways = true;
    // 惰性递归 ****
    if (item.parentId === "0") {
      obj.component = Main
    } else {
      // 惰性递归 ****
      let data = item.component
      if(item.children.length>0){
        obj.component = parentView
      }else{
        // 这里需要改成自己定义的 .vue 路径
        obj.component = () => import('@/view' + data)
      }
    }
    if (hasChild(item)) {
      obj.children = formatMenu(item.children)
    }
    res.push(obj)
  })
  return res
}
