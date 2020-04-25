const { notEmpty } = require('../utils.js');

module.exports = {
  description: 'generate a list component',
  prompts: [
    {
      type: 'input',
      name: 'module',
      message: '请输入module name',
      validate: notEmpty('module'),
    },
    {
      type: 'input',
      name: 'name',
      message: '请输入实体名',
      validate: notEmpty('name'),
    },
  ],

  actions: data => {
    const module = '{{module}}';
    const name = '{{name}}';
    const actions = [
      {
        type: 'add',
        path: `src/app/${module}/components/${name}-list/${name}-list.component.html`,
        templateFile: 'plop-templates/view_list/html.hbs',
      },
      {
        type: 'add',
        path: `src/app/${module}/components/${name}-list/${name}-list.component.ts`,
        templateFile: 'plop-templates/view_list/ts.hbs',
      },
      {
        type: 'add',
        path: `src/app/${module}/components/${name}-list/${name}-edit.component.ts`,
        templateFile: 'plop-templates/view_list/edit.hbs',
      },
    ];
    return actions;
  },
};
