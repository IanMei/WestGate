// 创建axios实例
var api = axios.create({ timeout: 1000 * 20 });
// 设置post请求头
api.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
api.defaults.responseType = 'json';
api.defaults.transformRequest = [
    function (data) {
        return Qs.stringify(data);
    }
];
/**
 * 请求拦截器
 * 每次请求前，如果存在token则在请求头中携带token
 */
api.interceptors.request.use(
    config => {
        // 登录流程控制中，根据本地是否存在token判断用户的登录情况
        // 但是即使token存在，也有可能token是过期的，所以在每次的请求头中携带token
        // 后台根据携带的token判断用户的登录情况，并返回给我们对应的状态码
        // 而后我们可以在响应拦截器中，根据状态码进行一些统一的操作。
        // const token = store.getters.token
        const token = localStorage.getItem('access-Token');
        // config.headers.common['Token'] = token || ''
        token && (config.headers.Token = token);
        return config;
    },
    error => Promise.error(error));

// respone拦截器
//api.interceptors.response.use(
//    response => {
//        const dataAxios = response.data
//        console.log(response)
//        // dataAxios 是 axios 返回数据中的 data
//        const dataAxios = response.data
//        //debugger
//        // 这个状态码是和后端约定的
//        const { code } = dataAxios
//        // 有 code 代表这是一个后端接口 可以进行进一步的判断
//        switch (code) {
//            case 401:
//                localStorage.removeItem('access-Token')
//                return Promise.resolve(dataAxios)
//            case 403:
//                return Promise.reject(dataAxios)
//            default:
//                // 不是正确的 code
//                // errorCreate(`${dataAxios.msg}: ${response.config.url}`)
//                return Promise.resolve(dataAxios)
//        }
//    },
//    error => {
//        const { response } = error;
//        if (response) {
//            return Promise.reject({ message: '网络连接错误' });
//        } else {
//            Promise.reject(error);
//        }
//    }
//)

// 响应拦截器
api.interceptors.response.use(
    // 请求成功
    res => {
        const { status } = res;
        //console.log(res)
        //debugger
        if (status === 200) {
            if (res.data.code === 70001) {
                tip('无权限，服务器拒绝执行');
                return Promise.reject(res.data)
            }
            else {
                return Promise.resolve(res.data);
            }
        }
        else {
            return Promise.reject(res.data)
        }
        //res.status === 200 ? Promise.resolve(res.data) : Promise.reject(res.data),
    },
    // 请求失败
    error => {
        const { response } = error;
        console.log(response);
        //debugger
        if (response) {
            // 请求已发出，但是不在2xx的范围
            errorHandle(response.status, response.data.message);
            return Promise.reject(response);
        } else {
            Promise.reject(error);
        }
    });

const tip = msg => {
    //console.log(this)
    this.ELEMENT.Message({
        message: msg,
        type: 'error'
    });
};

const errorHandle = (status, other) => {
    // 状态码判断
    switch (status) {
        // 401: 未登录状态，跳转登录页
        case 401:
            localStorage.removeItem('access-Token')
            break
        // 403 token过期
        // 清除token并跳转登录页
        case 403:
            //localStorage.removeItem('access-Token')
            tip('无权限，服务器拒绝执行');
            break;
        // 404请求不存在
        case 404:
            tip('请求的资源不存在');
            break;
        case 500:

            break;
        default:
            console.log(other);
    }
};