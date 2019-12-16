import axios from '@/libs/api.request'

export const getProductList = (data) => {
  return axios.request({
    withPrefix: false, 
    prefix: "api/",
    url: 'product/list',
    method: 'post',
    data
  });
};
export const importProduct = (data) => {
    return axios.request({
        withPrefix:false,
        prefix: "api/",
        url: 'product/import',
        method: 'post',
        data
    });
};