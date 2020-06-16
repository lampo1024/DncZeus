<template>
  <Form ref="loginForm" :model="form" :rules="rules" @keydown.enter.native="handleSubmit">
    <FormItem prop="userName">
      <Input v-model="form.userName" placeholder="请输入用户名">
        <span slot="prepend">
          <Icon :size="16" type="ios-person"></Icon>
        </span>
      </Input>
    </FormItem>
    <FormItem prop="password">
      <Input type="password" v-model="form.password" placeholder="请输入密码">
        <span slot="prepend">
          <Icon :size="14" type="md-lock"></Icon>
        </span>
      </Input>
    </FormItem>
    <FormItem label="测试账户">
      <RadioGroup v-model="form.userType" type="button" @on-change="handleUserTypeChange">
        <Radio label="超级管理员"></Radio>
        <Radio label="普通用户"></Radio>
      </RadioGroup>
    </FormItem>
    <FormItem>
      <Button
        :disabled="processing"
        @click="handleSubmit"
        type="primary"
        long
        :loading="loading"
      >{{btnLoginText}}</Button>
    </FormItem>
    <p class="login-tip">欢迎使用DncZeus通用权限管理框架</p>
  </Form>
</template>
<script>
export default {
  name: "LoginForm",
  props: {
    userNameRules: {
      type: Array,
      default: () => {
        return [{ required: true, message: "账号不能为空", trigger: "blur" }];
      }
    },
    passwordRules: {
      type: Array,
      default: () => {
        return [{ required: true, message: "密码不能为空", trigger: "blur" }];
      }
    },
    processing: {
      type: Boolean,
      default: false
    },
    loading: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      form: {
        userName: '',
        password: '',
        userType: 1
      }
    };
  },
  computed: {
    btnLoginText() {
      return this.processing ? "正在处理,请稍候..." : "登录";
    },
    rules() {
      return {
        userName: this.userNameRules,
        password: this.passwordRules
      };
    }
  },
  methods: {
    handleSubmit() {
      this.$refs.loginForm.validate(valid => {
        if (valid) {
          this.$emit("on-success-valid", {
            userName: this.form.userName,
            password: this.form.password
          });
        }
      });
    },
    handleUserTypeChange(val){
      switch(val){
        case "超级管理员":
          this.form.userName = "administrator";
          break;
        case "普通用户":
        this.form.userName = "admin";
        break;
      }
      this.form.password = "111111";
    }
  }
};
</script>
