const { notEmpty } = require('../utils.js');

module.exports = {
  description: 'generate store',
  prompts: [
    {
      type: 'input',
      name: 'moduleName',
      message: 'moduleName please',
      validate: notEmpty('moduleName'),
    },
    {
      type: 'input',
      name: 'name',
      message: 'store name please',
      validate: notEmpty('name'),
    },
  ],
  actions(data) {
    const name = '{{name}}';
    const moduleName = '{{moduleName}}';
    const actions = [
      {
        type: 'add',
        path: `src/app/${moduleName}/store/${name}.service.ts`,
        templateFile: 'plop-templates/store/service.hbs',
      },
      {
        type: 'add',
        path: `src/app/${moduleName}/store/${name}.query.ts`,
        templateFile: 'plop-templates/store/query.hbs',
      },
      {
        type: 'add',
        path: `src/app/${moduleName}/store/${name}.store.ts`,
        templateFile: 'plop-templates/store/store.hbs',
      },
    ];
    return actions;
  },
};
