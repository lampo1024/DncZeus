import axios from 'axios'
import store from '@/store'
import {
  getToken
} from '@/libs/util'
import {
  Message,
  Modal
} from 'iview'
import iView from 'iview'

// let token = getToken()
// axios.defaults.headers.common['Authorization'] = 'Bearer ' + token
// import { Spin } from 'iview'

const addErrorLog = errorInfo => {
  const {
    statusText,
    status,
    request: {
      responseURL
    }
  } = errorInfo
  let info = {
    type: 'ajax',
    code: status,
    mes: statusText,
    url: responseURL
  }
  if (!responseURL.includes('save_error_logger'))
    store.dispatch('addErrorLog', info)
}

class HttpRequest {
  constructor(baseUrl = baseURL) {
    this.baseUrl = baseUrl
    this.queue = {}
  }
  getInsideConfig() {
    const config = {
      baseURL: this.baseUrl,
      headers: {
        "Authorization": "Bearer " + getToken()
      }
    }
    return config
  }
  destroy(url) {
    delete this.queue[url]
    if (!Object.keys(this.queue).length) {
      // Spin.hide()
    }
  }

  showError(error) {
    if (!error.status) {
      Modal.error({
        title: "错误提示",
        content: "网络出错,请检查你的网络或者服务是否可用<br />请求地址:[" + error.config.url + "]",
        duration: 15,
        closable: false
      });
      iView.LoadingBar.finish();
      // Message.error({
      //   content: "网络出错,请检查你的网络或者服务是否可用",
      //   duration: 0
      // });
      return;
    }
    var status = error.response.status;
    switch (status) {
      case 400:
        break;
    }
    if (status != 200) {
      Modal.error({
        title: "错误提示",
        content: "请求资源错误",
        duration: 15,
        closable: true
      })
    }
  }

  interceptors(instance, url) {
    // 请求拦截
    instance.interceptors.request.use(config => {
      // 添加全局的loading...
      if (!Object.keys(this.queue).length) {
        // Spin.show() // 不建议开启，因为界面不友好
        iView.LoadingBar.start();
      }
      this.queue[url] = true
      return config
    }, error => {
      return Promise.reject(error)
    })
    // 响应拦截
    instance.interceptors.response.use(res => {
      iView.LoadingBar.finish();
      this.destroy(url)
      const {
        data,
        status
      } = res
      return {
        data,
        status
      }
    }, error => {
      this.destroy(url)
      let errorInfo = error.response
      if (!errorInfo) {
        const {
          request: {
            statusText,
            status
          },
          config
        } = JSON.parse(JSON.stringify(error))
        errorInfo = {
          statusText,
          status,
          request: {
            responseURL: config.url
          }
        }
      }
      addErrorLog(errorInfo)
      if (error.config.hideError == null || error.config.hideError == false) {
        this.showError(error);
      }


      iView.LoadingBar.finish();

      return Promise.reject(error)
    })
  }
  request(options) {
    const instance = axios.create()
    options = Object.assign(this.getInsideConfig(), options)
    this.interceptors(instance, options.url)
    return instance(options)
  }

}
export default HttpRequest
