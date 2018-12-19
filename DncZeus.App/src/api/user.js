import _axios from 'axios'
import config from '@/config'
import axios from '@/libs/api.request'

const authUrl = process.env.NODE_ENV === 'development' ? config.authUrl.dev : config.authUrl.pro

export const login = ({
  userName,
  password
}) => {
  return _axios.get(authUrl + '?username=' + userName + '&password=' + password)
}

export const getUserInfo = (token) => {
  return axios.request({
    url: 'account/profile',
    method: 'get'
  })
}

export const logout = (token) => {
  return new Promise((resolve, reject) => {
    resolve()
  })
}

export const getUnreadCount = () => {
  return axios.request({
    url: 'message/count',
    hideError: false,
    method: 'get'
  })
}

export const getMessage = () => {
  return axios.request({
    url: 'message/init',
    method: 'get'
  })
}

export const getContentByMsgId = msg_id => {
  return axios.request({
    url: 'message/content/' + msg_id,
    method: 'get'
  })
}

export const hasRead = msg_id => {
  return axios.request({
    url: 'message/has_read/' + msg_id,
    method: 'get',
  })
}

export const removeReaded = msg_id => {
  return axios.request({
    url: 'message/remove_readed/' + msg_id,
    method: 'get'
  })
}

export const restoreTrash = msg_id => {
  return axios.request({
    url: 'message/restore/' + msg_id,
    method: 'get'
  })
}
