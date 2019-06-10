import { createLocalVue } from "@vue/test-utils";
import Vuetify from "vuetify";

export default {
  create() {
    console.error = (...args) => {
      if (
        args[0].includes("[Vuetify]") &&
        args[0].includes("https://github.com/vuetifyjs/vuetify/issues/4068")
      )
        return;
      this.originalLogError(...args);
    };

    const localVue = createLocalVue();
    localVue.use(Vuetify);

    console.error = this.originalLogError;

    return localVue;
  }
};