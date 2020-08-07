const express = require('express');
const mongoose = require('mongoose');
const System = require('../models/System');
const router = express.Router();
const { ensureAuthenticated } = require('../config/auth');

// Dashboard

router.get('/', ensureAuthenticated, (req, res) => 
    System.find({}, function(err, result) {
        if (err) {
          res.send(err);
        } else {
          res.render('dashboard', {data: result});
          
        }
      })
)



module.exports = router;