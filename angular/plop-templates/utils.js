exports.notEmpty = name => {
  return v => {
    if (!v || v.trim === '') {
      return `${name} is 必填`;
    } else {
      return true;
    }
  };
};
