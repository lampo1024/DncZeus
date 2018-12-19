const hasPermission = {
  install(Vue, options) {
    Vue.directive('can', {
      bind(el, binding, vnode) {
        let checkPermission = vnode.context.$route.meta.checkPermission;
        if (!checkPermission) {
          return;
        }
        let permissionList = vnode.context.$route.meta.permissions;
        if (permissionList && permissionList.length && !permissionList.includes(binding.value)) {
          el.parentNode.removeChild(el);
        }
      }
    });
  }
};

export default hasPermission;
