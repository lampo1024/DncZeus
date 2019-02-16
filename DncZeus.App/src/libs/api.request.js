import HttpRequest from '@/libs/axios'
import config from '@/config'
const baseUrl = process.env.NODE_ENV === 'development' ? config.baseUrl.dev : config.baseUrl.pro
const prefix = config.baseUrl.prefix;
const axios = new HttpRequest(baseUrl,prefix)
export default axios
