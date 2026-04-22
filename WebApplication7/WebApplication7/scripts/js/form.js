  $(document).ready(function() {
    $('#contact_form').bootstrapValidator({
        // To use feedback icons, ensure that you use Bootstrap v3.1.0 or later
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            username: {
                validators: {
                    stringLength: {
                        min: 5,
                        max:8,
                    },
                    notEmpty: {
                        message: 'Please Supply  User Name'
                    }
                }
            },
            txtcname: {
                validators: {
                        stringLength: {
                        min: 2,
                    },
                        notEmpty: {
                        message: 'Please Supply Full Name'
                    }
                }
            },
             last_name: {
                validators: {
                     stringLength: {
                        min: 2,
                    },
                    notEmpty: {
                        message: 'Please supply  last name'
                    }
                }
             },
             fname: {
                 validators: {
                     stringLength: {
                         min: 2,
                     },
                     notEmpty: {
                         message: 'Please Supply  Father Name'
                     }
                 }
             },
             emailpass: {
                 validators: {
                     stringLength: {
                         min: 2,
                     },
                     notEmpty: {
                         message: 'Please Supply  Email Password'
                     }
                 }
             },
            email: {
                validators: {
                    notEmpty: {
                        message: 'Please Supply  Email Address'
                    },
                    emailAddress: {
                        message: 'Please Supply a valid Email Address'
                    }
                }
            },
            phone: {
                validators: {
                    notEmpty: {
                        message: 'Please Supply Mobile Number'
                    },
                    phone: {
                        country: 'US',
                        message: 'Please Supply a Vaild Mobile Number'
                    }
                }
            },
            address: {
                validators: {
                     stringLength: {
                        min: 8,
                    },
                    notEmpty: {
                        message: 'Please Supply  Residence Address'
                    }
                }
            },
            city: {
                validators: {
                     stringLength: {
                        min: 4,
                    },
                    notEmpty: {
                        message: 'Please supply your city'
                    }
                }
            },
            adharcard: {
                validators: {
                    stringLength: {
                        min: 12,
                        max:12,
                    },
                    notEmpty: {
                        message: 'Please Supply Adharcard Number'
                    }
                }
            },
            acno: {
                validators: {
                    stringLength: {
                        min: 10,                       
                    },
                    notEmpty: {
                        message: 'Please Supply A/C Number'
                    }
                }
            },
            gstno: {
                validators: {
                    stringLength: {
                        min: 15,
                        max: 15,
                    },
                    notEmpty: {
                        message: 'Please Supply GST Number'
                    }
                }
            },
            gstuid: {
                validators: {
                    stringLength: {
                        min: 3,                        
                    },
                    notEmpty: {
                        message: 'Please Supply GST User Id'
                    }
                }
            },
            gstpass: {
                validators: {
                    stringLength: {
                        min: 3,                       
                    },
                    notEmpty: {
                        message: 'Please Supply GST Password'
                    }
                }
            },
            division: {
                validators: {
                    stringLength: {
                        min: 3,                        
                    },
                    notEmpty: {
                        message: 'Please Supply Division/Circle Name'
                    }
                }
            },
            salary: {
                validators: {
                    stringLength: {
                        min: 3,                        
                    },
                    notEmpty: {
                        message: 'Please Supply Salary'
                    }
                }
            },
            panno: {
                validators: {
                    stringLength: {
                        min: 3,
                    },
                    notEmpty: {
                        message: 'Please Supply PAN Number'
                    }
                }
            },
            program: {
                validators: {
                    notEmpty: {
                        message: 'Please select your program'
                    }
                }
            },
			course_title: {
                validators: {
                    notEmpty: {
                        message: 'Please select your course_title'
                    }
                }
            },
			study_mode: {
                validators: {
                    notEmpty: {
                        message: 'Please select your study_mode'
                    }
                }
            },
			country: {
                validators: {
                    notEmpty: {
                        message: 'Please select your country'
                    }
                }
            },
            zip: {
                validators: {
                    notEmpty: {
                        message: 'Please supply your zip code'
                    },
                    zipCode: {
                        country: 'US',
                        message: 'Please supply a vaild zip code'
                    }
                }
            },
            comment: {
                validators: {
                      stringLength: {
                        min: 10,
                        max: 200,
                        message:'Please enter at least 10 characters and no more than 200'
                    },
                    notEmpty: {
                        message: 'Please supply your Specific Query'
                    }
                    }
                }
            }
        })
        .on('success.form.bv', function(e) {
            $('#success_message').slideDown({ opacity: "show" }, "slow") // Do something ...
                $('#contact_form').data('bootstrapValidator').resetForm();

            // Prevent form submission
            e.preventDefault();

            // Get the form instance
            var $form = $(e.target);

            // Get the BootstrapValidator instance
            var bv = $form.data('bootstrapValidator');

            // Use Ajax to submit form data
            $.post($form.attr('action'), $form.serialize(), function(result) {
                console.log(result);
            }, 'json');
      });

    //$('#btnsave').click(function () {
    //    $('#contact_form').bootstrapValidator('validate');
    //});

    //$('#btn_cancel').click(function () {
    //    $('#form1').data('bootstrapValidator').resetForm(true);
    //});
});
