$(document).ready(function () {
            //$('input[type = text],input[type = password]').val(''); // not affecting if comment or un-comment 
            $('#formvalidate').bootstrapValidator({
                //live: 'disabled',
                //message: 'This value is not valid',
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    txtusername: {                     
                        message: 'The username is not valid',
                        validators: {
                            notEmpty: {
                                message: 'The username is required and cannot be empty'
                            },
                            stringLength: {
                                min: 6,
                                max: 30,
                                message: 'The username must be more than 6 and less than 30 characters long'
                            }
                        }
                    },
                    txtpassword: {                        
                        message: 'The password is not valid',
                        validators: {
                            notEmpty: {
                                message: 'The password is required and cannot be empty'
                            },
                            stringLength: {
                                min: 6,
                                max: 30,
                                message: 'The password must be more than 6 and less than 30 characters long'
                            }
                        }
                    },
                    txtcname: {                     
                        message: 'The name is not valid',
                        validators: {
                            notEmpty: {
                                message: 'Please supply full name'
                            },
                            stringLength: {
                                min: 3,
                                max: 30,
                                message: 'The name must be more than 3 and less than 30 characters long'
                            }
                        }
                    },                
                txtfname1: {                    
                    message: 'The father name is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Please supply full father name'
                        },
                        stringLength: {
                            min: 3,
                            max: 30,
                            message: 'The father name must be more than 3 and less than 30 characters long'
                        }
                    }
                },
                txtpanno1: {                    
                    message: 'The PAN No. is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Please supply full PAN number'
                        },
                        stringLength: {
                            min: 10,                            
                            message: 'The PAN number must be more than 10  characters long'
                        }
                    }
                },
                txtadharno1: {                    
                    message: 'The adharcard No. is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Please supply full adharcard number'
                        },
                        stringLength: {
                            min: 12,
                            max:12,
                            message: 'The adharcard number must be 12  characters long'
                        }
                    }
                },
                txtcity: {
                    message: 'The salary is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Please supply city name'
                        },
                        stringLength: {
                            min: 3,                            
                            message: 'The city must be 3 characters long'
                        }
                    }
                },
                txtaddress1: {                   
                    message: 'The address is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Please supply full permanent Address'
                        },
                        stringLength: {
                            min: 5,
                            max: 250,
                            message: 'The permanent Address must be 250  characters long'
                        }
                    }
                },
                txtemail: {
                    validators: {
                        notEmpty: {
                            message: 'Please Supply  Email Address'
                        },
                        emailAddress: {
                            message: 'Please Supply a valid Email Address'
                        }
                    }
                },
                txtemailpass: {                    
                    message: 'The email password is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Please supply email password'
                        },                        
                    }
                },
                txtmobile: {
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
                txtgstno: {                    
                    message: 'The GST no. is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Please supply full GST Number'
                        },
                        stringLength: {
                            min: 15,
                            max: 15,
                            message: 'The GST Number must be 15 characters long'
                        }
                    }
                },
                ddlpackage: {
                    message: 'The date is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Please select Package'
                        },                        
                    }
                },
                ddlepin: {                  
                    message: 'The GST User id is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Please select an E-Pin'
                        },                       
                    }
                },
                txtgstpass: {                    
                    message: 'The GST User password is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Please supply full GST User password'
                        },
                    }
                },
                txtsid: {
                    message: 'The Sponsor is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Please supply Sponsor id'
                        },
                    }
                },
                txtacno: {            
                message: 'The A/C No. is not valid',
                validators: {
                    notEmpty: {
                        message: 'Please supply full A/C number'
                    },
                    stringLength: {
                        min: 10,
                        max: 15,
                        message: 'The A/C number must be more than 10 and less than 15 characters long'
                    }
                }
            }
           },

            });


            $('#btnsave').click(function () {
                $('#formvalidate').bootstrapValidator('validate');
            });

            $('#btncancel').click(function () {
                $('#contact_form').data('bootstrapValidator').resetForm(true);
            });

        });
