<template>
  <div>
    <Card>
      <tables
        ref="tables"
        editable
        searchable
        :border="false"
        size="small"
        search-place="top"
        v-model="stores.product.data"
        :totalCount="stores.product.query.totalCount"
        :columns="stores.product.columns"
        @on-delete="handleDelete"
        @on-edit="handleEdit"
        @on-select="handleSelect"
        @on-select-cancel="handleSelectCancel"
        @on-selection-change="handleSelectionChange"
        @on-refresh="handleRefresh"
        :row-class-name="rowClsRender"
        @on-page-change="handlePageChanged"
        @on-page-size-change="handlePageSizeChanged"
      >
        <div slot="search">
          <section class="dnc-toolbar-wrap">
            <Row :gutter="16">
              <Col span="3">
                <Input
                  type="text"
                  search
                  :clearable="true"
                  v-model="stores.product.query.itemNo"
                  placeholder="输入料件号..."
                  @on-search="handleSearchProduct()"
                ></Input>
              </Col>
              <Col span="3">
                <Input
                  type="text"
                  search
                  :clearable="true"
                  v-model="stores.product.query.type"
                  placeholder="输入型号..."
                  @on-search="handleSearchProduct()"
                ></Input>
              </Col>
              <Col span="3">
                <Input
                  type="text"
                  search
                  :clearable="true"
                  v-model="stores.product.query.country"
                  placeholder="输入原产国..."
                  @on-search="handleSearchProduct()"
                ></Input>
              </Col>
              <Col span="3">
                <Input
                  type="text"
                  search
                  :clearable="true"
                  v-model="stores.product.query.brand"
                  placeholder="输入品牌..."
                  @on-search="handleSearchProduct()"
                ></Input>
              </Col>
              <Col span="3">
                <Input
                  type="text"
                  search
                  :clearable="true"
                  v-model="stores.product.query.name_en"
                  placeholder="输入英文品名..."
                  @on-search="handleSearchProduct()"
                ></Input>
              </Col>
              <Col span="9" class="dnc-toolbar-btns">
                <!-- <ButtonGroup class="mr3">
                  <Button
                    class="txt-danger"
                    icon="md-trash"
                    title="删除"
                    @click="handleBatchCommand('delete')"
                  ></Button>
                  <Button
                    class="txt-success"
                    icon="md-redo"
                    title="恢复"
                    @click="handleBatchCommand('recover')"
                  ></Button>
                  <Button
                    class="txt-danger"
                    icon="md-hand"
                    title="禁用"
                    @click="handleBatchCommand('forbidden')"
                  ></Button>
                  <Button
                    class="txt-success"
                    icon="md-checkmark"
                    title="启用"
                    @click="handleBatchCommand('normal')"
                  ></Button>
                  <Button icon="md-refresh" title="刷新" @click="handleRefresh"></Button>
                </ButtonGroup>-->
                <Button icon="md-search" type="primary" @click="handleRefresh" title="查询">查询</Button>
                <Button
                  icon="md-search"
                  v-can="'export'"
                  type="primary"
                  @click="handleExport"
                  title="查询"
                >导出</Button>
                <Upload :before-upload="handleImport" action>
                  <Button icon="ios-cloud-upload-outline">导入</Button>
                </Upload>
                <!-- <Button icon="md-search" v-can="'import'" type="primary" title="导入">
                  <input type="file" accept=".xlsx, .xls" @change="handleImport"></input>导入
                </Button>-->
                <!-- <Button icon="md-search" v-can="'import'" type="primary" @click="handleImport" title="查询">导入</Button> -->
                <!-- <Button
                  icon="md-create"
                  type="primary"
                  @click="handleShowCreateWindow"
                  title="新增"
                >新增</Button>-->
              </Col>
            </Row>
          </section>
        </div>
      </tables>
    </Card>
    <Drawer
      :title="formTitle"
      v-model="formModel.opened"
      width="400"
      :mask-closable="false"
      :mask="false"
      :styles="styles"
    >
      <Form :model="formModel.fields" ref="formIcon" :rules="formModel.rules">
        <FormItem label="图标名称" prop="code" label-position="left">
          <Input v-model="formModel.fields.code" placeholder="请输入图标名称" />
        </FormItem>
        <FormItem label="自定义图标" label-position="top">
          <Input v-model="formModel.fields.custom" placeholder="请输入自定义图标" />
        </FormItem>
        <Row :gutter="8">
          <Col span="12">
            <FormItem label="图标状态" label-position="left">
              <i-switch
                size="large"
                v-model="formModel.fields.status"
                :true-value="1"
                :false-value="0"
              >
                <span slot="open">正常</span>
                <span slot="close">禁用</span>
              </i-switch>
            </FormItem>
          </Col>
          <Col span="12">
            <FormItem label="图标大小" label-position="left">
              <InputNumber v-model="formModel.fields.size" placeholder="图标大小"></InputNumber>
            </FormItem>
          </Col>
        </Row>
        <Row :gutter="8">
          <Col span="12">
            <FormItem label="图标颜色" label-position="top">
              <ColorPicker v-model="formModel.fields.color" placeholder="图标颜色" />
            </FormItem>
          </Col>
        </Row>
        <FormItem label="备注" label-position="top">
          <Input
            type="textarea"
            v-model="formModel.fields.description"
            :rows="4"
            placeholder="图标备注信息"
          />
        </FormItem>
      </Form>
      <div class="demo-drawer-footer">
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitIcon">保 存</Button>
        <Button style="margin-left: 8px" icon="md-close" @click="formModel.opened = false">取 消</Button>
        <Button
          style="margin-left: 8px"
          icon="md-arrow-up"
          @click="handleOpenBatchImportDrawer"
        >批量导入</Button>
      </div>
    </Drawer>
    <Drawer
      title="批量导入图标"
      v-model="formModel.batchImport.opened"
      width="360"
      :mask-closable="false"
    >
      <Form>
        <FormItem label="批量图标" label-position="top">
          <Input
            type="textarea"
            v-model="formModel.batchImport.icons"
            :rows="16"
            placeholder="以回车分隔,每行一个图标名称"
          />
        </FormItem>
      </Form>
      <div class="demo-drawer-footer">
        <Button icon="md-checkmark-circle" type="primary" @click="handleBatchSubmitIcon">保 存</Button>
        <Button
          style="margin-left: 8px"
          icon="md-close"
          @click="formModel.batchImport.opened = false"
        >取 消</Button>
      </div>
    </Drawer>
  </div>
</template>

<script>
import Tables from "_c/tables";
import { getProductList, importProduct } from "@/api/product";
import * as XLSX from "xlsx";
export default {
  name: "product_declar",
  components: {
    Tables
  },
  data() {
    return {
      file: null,
      commands: {
        // delete: { name: "delete", title: "删除" },
        // recover: { name: "recover", title: "恢复" },
        // forbidden: { name: "forbidden", title: "禁用" },
        // normal: { name: "normal", title: "启用" }
      },
      formModel: {
        opened: false,
        title: "添加产品",
        mode: "create",
        selection: [],
        fields: {
          id: 0,
          code: "",
          size: 24,
          color: "",
          custom: "",
          isLocked: 0,
          status: 1,
          isDeleted: 0,
          description: ""
        },
        rules: {
          code: [
            {
              type: "string",
              required: true,
              message: "请输入图标名称",
              min: 2
            }
          ]
        },
        batchImport: {
          opened: false,
          icons: ""
        }
      },
      stores: {
        product: {
          query: {
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            itemNo: "",
            type: "",
            country: "",
            brand: "",
            name_en: "",
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          },
          columns: [
            { type: "selection", width: 30, key: "handle" },
            { title: "料件号", key: "itemNo", width: 120 },
            { title: "型号", key: "type", width: 100 },
            { title: "原产国", key: "country", width: 100 },
            { title: "品牌", key: "brand", width: 100 },
            { title: "税号", key: "texNo", width: 120 },
            { title: "英文品名", key: "name_en", width: 200 },
            { title: "中文品名", key: "name_zh", width: 200 },
            { title: "申报要素", key: "element", width: 500 },
            { title: "备注", key: "note", width: 200 }
          ],
          data: [],
          selection: []
        }
      },
      styles: {
        height: "calc(100% - 55px)",
        overflow: "auto",
        paddingBottom: "53px",
        position: "static"
      }
    };
  },
  computed: {
    formTitle() {
      if (this.formModel.mode === "create") {
        return "创建图标";
      }
      if (this.formModel.mode === "edit") {
        return "编辑图标";
      }
      return "";
    },
    selectedRows() {
      return this.formModel.selection;
    },
    selectedRowsId() {
      return this.formModel.selection.map(x => x.id);
    }
  },
  methods: {
    loadProductList() {
      getProductList(this.stores.product.query).then(res => {
        this.stores.product.data = res.data.data;
        this.stores.product.query.totalCount = res.data.totalCount;
      });
    },
    handleOpenFormWindow() {
      this.formModel.opened = true;
    },
    handleCloseFormWindow() {
      this.formModel.opened = false;
    },
    handleSwitchFormModeToCreate() {
      this.formModel.mode = "create";
    },
    handleSwitchFormModeToEdit() {
      this.formModel.mode = "edit";
      this.handleOpenFormWindow();
    },
    handleEdit(params) {
      this.handleSwitchFormModeToEdit();
      this.handleResetFormIcon();
      this.doLoadIcon(params.row.id);
    },
    handleSelect(selection, row) {
      this.stores.product.selection = selection;
    },
    handleSelectCancel(selection, row) {
      this.stores.product.selection = selection;
    },
    handleSelectionChange(selection) {
      this.formModel.selection = selection;
    },
    handleRefresh() {
      this.loadProductList();
    },
    handleShowCreateWindow() {
      this.handleSwitchFormModeToCreate();
      this.handleOpenFormWindow();
      this.handleResetFormIcon();
    },
    handleSubmitIcon() {
      let valid = this.validateIconForm();
      if (valid) {
        if (this.formModel.mode === "create") {
          this.doCreateIcon();
        }
        if (this.formModel.mode === "edit") {
          this.doEditIcon();
        }
      }
    },
    handleResetFormIcon() {
      this.$refs["formIcon"].resetFields();
    },
    doCreateIcon() {
      // createIcon(this.formModel.fields).then(res => {
      //   if (res.data.code === 200) {
      //     this.$Message.success(res.data.message);
      //     this.loadProductList();
      //     this.handleCloseFormWindow();
      //   } else {
      //     this.$Message.warning(res.data.message);
      //   }
      // });
    },
    doEditIcon() {
      // editIcon(this.formModel.fields).then(res => {
      //   if (res.data.code === 200) {
      //     this.$Message.success(res.data.message);
      //     this.loadProductList();
      //     this.handleCloseFormWindow();
      //   } else {
      //     this.$Message.warning(res.data.message);
      //   }
      // });
    },
    validateIconForm() {
      let _valid = false;
      this.$refs["formIcon"].validate(valid => {
        if (!valid) {
          this.$Message.error("请完善表单信息");
          _valid = false;
        } else {
          _valid = true;
        }
      });
      return _valid;
    },
    doLoadIcon(id) {
      // loadIcon({ id: id }).then(res => {
      //   this.formModel.fields = res.data.data;
      // });
    },
    handleDelete(params) {
      this.doDelete(params.row.id);
    },
    doDelete(ids) {
      if (!ids) {
        this.$Message.warning("请选择至少一条数据");
        return;
      }
      // deleteIcon(ids).then(res => {
      //   if (res.data.code === 200) {
      //     this.$Message.success(res.data.message);
      //     this.loadProductList();
      //   } else {
      //     this.$Message.warning(res.data.message);
      //   }
      // });
    },
    handleBatchCommand(command) {
      if (!this.selectedRowsId || this.selectedRowsId.length <= 0) {
        this.$Message.warning("请选择至少一条数据");
        return;
      }
      this.$Modal.confirm({
        title: "操作提示",
        content:
          "<p>确定要执行当前 [" +
          this.commands[command].title +
          "] 操作吗?</p>",
        loading: true,
        onOk: () => {
          this.doBatchCommand(command);
        }
      });
    },
    doBatchCommand(command) {
      // batchCommand({
      //   command: command,
      //   ids: this.selectedRowsId.join(",")
      // }).then(res => {
      //   if (res.data.code === 200) {
      //     this.$Message.success(res.data.message);
      //     this.handleCloseFormWindow();
      //     this.formModel.batchImport.opened = false;
      //     this.loadProductList();
      //     this.formModel.selection = [];
      //   } else {
      //     this.$Message.warning(res.data.message);
      //   }
      //   this.$Modal.remove();
      // });
    },
    handleSearchIcon() {
      this.loadProductList();
    },
    rowClsRender(row, index) {
      if (row.isDeleted) {
        return "table-row-disabled";
      }
      return "";
    },
    handleOpenBatchImportDrawer() {
      this.formModel.batchImport.opened = true;
    },
    handleBatchSubmitIcon() {
      var data = { icons: this.formModel.batchImport.icons };
      // batchImportIcon(data).then(res => {
      //   if (res.data.code === 200) {
      //     this.$Message.success(res.data.message);
      //     this.handleCloseFormWindow();
      //     this.formModel.batchImport.opened = false;
      //     this.loadProductList();
      //   } else {
      //     this.$Message.warning(res.data.message);
      //   }
      // });
    },
    handlePageChanged(page) {
      this.stores.product.query.currentPage = page;
      this.loadProductList();
    },
    handlePageSizeChanged(pageSize) {
      this.stores.product.query.pageSize = pageSize;
      this.loadProductList();
    },
    handleImport(file) {
      var reader = new FileReader();
      reader.onload = event => {
        // 以二进制流方式读取得到整份excel表格对象
        const workbook = XLSX.read(event.target.result, { type: "binary" });
        // 存储获取到的数据
        let data = [];
        // 遍历每张工作表进行读取（这里默认只读取第一张表）
        for (const sheet in workbook.Sheets) {
          // esline-disable-next-line
          if (workbook.Sheets.hasOwnProperty(sheet)) {
            // 利用 sheet_to_json 方法将 excel 转成 json 数据
            data = data.concat(
              XLSX.utils.sheet_to_json(workbook.Sheets[sheet])
            );
            break; // 只取第一张表
          }
        }
        console.log(data);
        const uploadData = data.map(item => {
          return {
            ItemNo: item["料件号"],
            Type: item["型号"],
            Country: item["原产国"],
            Brand: item["品牌"],
            TexNo: item["税号"],
            Name_en: item["英文品名"],
            Name_zh: item["中文品名"],
            Element: item["申报要素"],
            Note: item["备注"]
          };
        }); //映射对象数据
        console.log(uploadData);
        importProduct(uploadData);
        this.loadProductList();
      };
      reader.readAsBinaryString(file);

      return false;
    },
    handleExport() {
      console.log(this.stores.product.selection);
      if (
        !this.stores.product.selection ||
        this.stores.product.selection.length < 1
      ) {
        this.$Message.warning("请选择至少一条数据");
        return;
      }
      let jsondata = JSON.parse(
        JSON.stringify(this.stores.product.selection)
      ); //深拷贝原始数据
      let data = jsondata.map(item => {
        return {
          料件号: item.itemNo,
          型号: item.type,
          原产国: item.country,
          品牌: item.brand,
          税号: item.texNo,
          英文品名: item.name_en,
          中文品名: item.name_zh,
          申报要素: item.element,
          备注: item.note
        };
      }); //对象映射
      download(data, "申报要素.xlsx");
    }
  },
  mounted() {
    this.loadProductList();
  }
};
function download(json, fileName) {
  const type = "xlsx"; //定义导出文件的格式
  var tmpDown; //导出的内容
  var tmpdata = json[0];
  json.unshift({});
  var keyMap = []; //获取keys
  for (var k in tmpdata) {
    keyMap.push(k);
    json[0][k] = k;
  }
  var tmpdata = []; //用来保存转换好的json

  json
    .map((v, i) =>
      keyMap.map((k, j) =>
        Object.assign(
          {},
          {
            v: v[k],
            position:
              (j > 25 ? getCharCol(j) : String.fromCharCode(65 + j)) + (i + 1)
          }
        )
      )
    )
    .reduce((prev, next) => prev.concat(next))
    .forEach(
      (v, i) =>
        (tmpdata[v.position] = {
          v: v.v
        })
    );
  var outputPos = Object.keys(tmpdata); //设置区域,比如表格从A1到D10
  var tmpWB = {
    SheetNames: ["mySheet"], //保存的表标题
    Sheets: {
      mySheet: Object.assign(
        {},
        tmpdata, //内容
        {
          "!ref": outputPos[0] + ":" + outputPos[outputPos.length - 1] //设置填充区域
        }
      )
    }
  };
  tmpDown = new Blob(
    [
      s2ab(
        XLSX.write(
          tmpWB,
          {
            bookType: type == undefined ? "xlsx" : type,
            bookSST: false,
            type: "binary"
          } //这里的数据是用来定义导出的格式类型
        )
      )
    ],
    {
      type: ""
    }
  ); //创建二进制对象写入转换好的字节流
  saveAs(tmpDown, fileName);
}

function saveAs(obj, fileName) {
  //导出功能实现
  var tmpa = document.createElement("a");
  tmpa.download = fileName || "下载";
  tmpa.href = URL.createObjectURL(obj); //绑定a标签
  tmpa.click(); //模拟点击实现下载
  setTimeout(function() {
    //延时释放
    URL.revokeObjectURL(obj); //用URL.revokeObjectURL()来释放这个object URL
  }, 100);
}

function s2ab(s) {
  //字符串转字符流
  var buf = new ArrayBuffer(s.length);
  var view = new Uint8Array(buf);
  for (var i = 0; i != s.length; ++i) view[i] = s.charCodeAt(i) & 0xff;
  return buf;
}

function getCharCol(n) {
  let temCol = "",
    s = "",
    m = 0;
  while (n > 0) {
    m = (n % 26) + 1;
    s = String.fromCharCode(m + 64) + s;
    n = (n - m) / 26;
  }
  return s;
}
</script>
