/**
 * @description 创建菜单
 * @param {Function} h createElement
 * @param {Object} menu 菜单项
 */
export function elMenuItem (h, menu) {
  let icon = null
  if (menu.icon) icon = <i style="margin-top:-4px;" class={ `fa fa-${menu.icon}` }/>
  else if (menu.iconSvg) icon = <d2-icon-svg style="margin-top:-4px;" name={ menu.iconSvg }/>
  else icon = <i style="margin-top:-4px;" class="fa fa-file-o"/>
  return <el-menu-item
    key={ menu.path }
    index={ menu.path }>
    { icon }
    <span slot="title">{ menu.title || '未命名菜单' }</span>
  </el-menu-item>
}

/**
 * @description 创建子菜单
 * @param {Function} h createElement
 * @param {Object} menu 菜单项
 */
export function elSubmenu (h, menu) {
  let icon = null
  if (menu.icon) icon = <i slot="title" style="margin-top:-4px;" class={ `fa fa-${menu.icon}` }/>
  else if (menu.iconSvg) icon = <d2-icon-svg slot="title" style="margin-top:-4px;" name={ menu.iconSvg }/>
  else icon = <i slot="title" style="margin-top:-4px;" class="fa fa-folder-o"/>
  return <el-submenu
    key={ menu.path }
    index={ menu.path }>
    { icon }
    <span slot="title">{ menu.title || '未命名菜单' }</span>
    { menu.children.map(child => createMenu.call(this, h, child)) }
  </el-submenu>
}

/**
 * @description 在组件中调用此方法渲染菜单项目
 * @param {Function} h createElement
 * @param {Object} menu 菜单项
 */
export function createMenu (h, menu) {
  if (menu.children === undefined) return elMenuItem.call(this, h, menu)
  return elSubmenu.call(this, h, menu)
}
