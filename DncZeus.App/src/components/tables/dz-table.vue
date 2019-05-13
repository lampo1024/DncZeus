<template>
  <div class="dnc-table-wrap">
    <slot name="searcher">
      <div v-if="searchable && searchPlace === 'top'" class="search-con search-con-top">
        <Input
          @on-change="handleClear"
          clearable
          placeholder="输入关键字搜索"
          class="search-input"
          v-model="searchValue"
        />
        <Button @click="handleSearch" class="search-btn" type="primary">
          <Icon type="search"/>&nbsp;&nbsp;搜索
        </Button>
      </div>
    </slot>
    <slot name="table">暂无数据</slot>
    <div style="margin-top:15px;">
      <slot name="pager">
        <Page
          :total="totalCount"
          :page-size="pageSize"
          size="small"
          show-elevator
          show-sizer
          show-total
          :page-size-opts="pageSizeOpts"
          @on-change="onPageChanged"
          @on-page-size-change="onPageSizeChanged"
        ></Page>
      </slot>
    </div>
  </div>
</template>
<script>
export default {
  name: "DzTable",
  data() {
    return {
      searchValue: ""
    };
  },
  props: {
    /**
     * @description 是否可搜索
     */
    searchable: {
      type: Boolean,
      default: false
    },
    /**
     * @description 搜索控件所在位置，'top' / 'bottom'
     */
    searchPlace: {
      type: String,
      default: "top"
    },
    totalCount: {
      type: Number,
      default: 0
    },
    pageSize: {
      type: Number,
      default: 20
    },
    showRefreshButton: {
      type: Boolean,
      default: false
    },
    pageSizeOpts: {
      type: Array,
      default() {
        return [5, 10, 20, 30, 40, 50];
      }
    }
  },
  methods: {
    handleClear() {},
    handleSearch() {
      this.$emit("on-search");
    },
    onPageChanged(page) {
      this.$emit("on-page-change", page);
    },
    onPageSizeChanged(pageSize) {
      this.$emit("on-page-size-change", pageSize);
    }
  }
};
</script>
<style>
.table-command-column button{margin-right: 2px;}
</style>
