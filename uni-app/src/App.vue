<script>
import { mapMutations, mapActions, mapState } from "vuex";
export default {
  created() {
    this.getUserInfo().then(
      res => {
        console.log("%c App created getUserInfo back", "color:green");
        console.log(res);
        this.setUserInfo(res);
      },
      err => {
        console.log("%c App created getUserInfo back Err", "color:red");
        console.log(err);
      }
    );
  },
  methods: {
    ...mapActions(["setUserInfo"]),
    getUserInfo() {
      var that = this;
      return new Promise((resolve, reject) => {
        wx.login({
          success: logRes => {
            wx.getUserInfo({
              success: res => {
                res.code = logRes.code;
                return resolve(res);
              }
            });
          },
          fail: error => {
            return reject(error);
          }
        });
      });
    }
  }
};
</script>

<style lang="scss">
@import "styles/commom.scss";
</style>
