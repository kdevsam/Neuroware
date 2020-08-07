const mongoose = require('mongoose');

const sysSchema = new mongoose.Schema({
    
        sys_id: {
          type: Number
        },
        life: {
          type: Number
        },
        charging: {
          type: String
        }
      },
      { collection: "Systems" }

);

const System = mongoose.model('System', sysSchema);
module.exports = System;