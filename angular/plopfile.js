const viewGenerator = require('./plop-templates/view/prompt');
const viewListGenerator = require('./plop-templates/view_list/prompt');
const componentGenerator = require('./plop-templates/component/prompt');
const storeGenerator = require('./plop-templates/store/prompt.js');

module.exports = function(plop) {
  plop.setGenerator('view', viewGenerator);
  plop.setGenerator('view_list', viewListGenerator);
  plop.setGenerator('component', componentGenerator);
  plop.setGenerator('store', storeGenerator);
};
