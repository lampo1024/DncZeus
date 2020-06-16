<template>
  <component :is="iconType" :type="iconName" :color="iconColor" :size="iconSize"/>
</template>

<script>
import Icons from '_c/icons'
export default {
  name: 'CommonIcon',
  components: {Icons},
  props: {
    type: {
      type: String,
      required: true,
       default () {
        return "Icon"
      }
    },
    color: String,
    size: Number
  },
  computed: {
    iconType () {
      if(this.type)
      {
        return this.type.indexOf('_') === 0 ? 'Icons' : 'Icon'
      }
      else{
        return "Icon"
      }
    },
    iconName () {
      return this.iconType === 'Icons' ? this.getCustomIconName(this.type) : this.type
    },
    iconSize () {
      return this.size || (this.iconType === 'Icons' ? 12 : undefined)
    },
    iconColor () {
      return this.color || ''
    }
  },
  methods: {
    getCustomIconName (iconName) {
      return iconName.slice(1)
    }
  }
}
</script>

<style>

</style>
