$('.persian-datePicker').persianDatepicker({
			"inline": false,
			"format": "YYYY/MM/DD",
			"viewMode": "day",
			"initialValue": true,
			"minDate": null,
			"maxDate": null,
			"autoClose": true,
			"position": "auto",
			"altFormat": "l",
			"altField": "#altfieldExample",
			"onlyTimePicker": false,
			"onlySelectOnDate": true,
			"calendarType": "persian",
			"inputDelay": 800,
			"observer": false,
			"calendar": {
				"persian": {
					"locale": "fa",
					"showHint": true,
					"leapYearMode": "algorithmic"
				},
				"gregorian": {
					"locale": "en",
					"showHint": true
				}
			},
			"navigator": {
				"enabled": true,
				"scroll": {
					"enabled": true
				},
				"text": {
					"btnNextText": "<",
					"btnPrevText": ">"
				}
			},
			"toolbox": {
				"enabled": false,
				"calendarSwitch": {
					"enabled": true,
					"format": "MMMM"
				},
				"todayButton": {
					"enabled": true,
					"text": {
						"fa": "امروز",
						"en": "Today"
					}
				},
				"submitButton": {
					"enabled": true,
					"text": {
						"fa": "تایید",
						"en": "Submit"
					}
				},
				"text": {
					"btnToday": "امروز"
				}
			},
			"timePicker": {
				"enabled": false,
				"step": 1,
				"hour": {
					"enabled": false,
					"step": null
				},
				"minute": {
					"enabled": false,
					"step": null
				},
				"second": {
					"enabled": false,
					"step": null
				},
				"meridian": {
					"enabled": false
				}
			},
			"dayPicker": {
				"enabled": true,
				"titleFormat": "YYYY MMMM"
			},
			"monthPicker": {
				"enabled": true,
				"titleFormat": "YYYY"
			},
			"yearPicker": {
				"enabled": true,
				"titleFormat": "YYYY"
			},
			"responsive": false
});


$('.persian-dateTimePicker').persianDatepicker({
	"inline": false,
	"format": "HH:mm - YYYY/MM/DD",
	"viewMode": "day",
	"initialValue": true,
	"minDate": null,
	"maxDate": null,
	"autoClose": true,
	"position": "auto",
	"altFormat": "l",
	"altField": "#altfieldExample",
	"onlyTimePicker": false,
	"onlySelectOnDate": true,
	"calendarType": "persian",
	"inputDelay": 800,
	"observer": false,
	"calendar": {
		"persian": {
			"locale": "fa",
			"showHint": true,
			"leapYearMode": "algorithmic"
		},
		"gregorian": {
			"locale": "en",
			"showHint": true
		}
	},
	"navigator": {
		"enabled": true,
		"scroll": {
			"enabled": true
		},
		"text": {
			"btnNextText": "<",
			"btnPrevText": ">"
		}
	},
	"toolbox": {
		"enabled": false,
		"calendarSwitch": {
			"enabled": true,
			"format": "MMMM"
		},
		"todayButton": {
			"enabled": true,
			"text": {
				"fa": "امروز",
				"en": "Today"
			}
		},
		"submitButton": {
			"enabled": true,
			"text": {
				"fa": "تایید",
				"en": "Submit"
			}
		},
		"text": {
			"btnToday": "امروز"
		}
	},
	"timePicker": {
		"enabled": true,
		"step": 1,
		"hour": {
			"enabled": true,
			"step": null
		},
		"minute": {
			"enabled": true,
			"step": null
		},
		"second": {
			"enabled": false,
			"step": null
		},
		"meridian": {
			"enabled": false
		}
	},
	"dayPicker": {
		"enabled": true,
		"titleFormat": "YYYY MMMM"
	},
	"monthPicker": {
		"enabled": true,
		"titleFormat": "YYYY"
	},
	"yearPicker": {
		"enabled": true,
		"titleFormat": "YYYY"
	},
	"responsive": false
});

$('.persian-datePicker-noInitialValue').persianDatepicker({
	"inline": false,
	"format": "YYYY/MM/DD",
	"viewMode": "day",
	"initialValue": false,
	"minDate": null,
	"maxDate": null,
	"autoClose": true,
	"position": "auto",
	"altFormat": "l",
	"altField": "#altfieldExample",
	"onlyTimePicker": false,
	"onlySelectOnDate": true,
	"calendarType": "persian",
	"inputDelay": 800,
	"observer": false,
	"calendar": {
		"persian": {
			"locale": "fa",
			"showHint": true,
			"leapYearMode": "algorithmic"
		},
		"gregorian": {
			"locale": "en",
			"showHint": true
		}
	},
	"navigator": {
		"enabled": true,
		"scroll": {
			"enabled": true
		},
		"text": {
			"btnNextText": "<",
			"btnPrevText": ">"
		}
	},
	"toolbox": {
		"enabled": false,
		"calendarSwitch": {
			"enabled": true,
			"format": "MMMM"
		},
		"todayButton": {
			"enabled": true,
			"text": {
				"fa": "امروز",
				"en": "Today"
			}
		},
		"submitButton": {
			"enabled": true,
			"text": {
				"fa": "تایید",
				"en": "Submit"
			}
		},
		"text": {
			"btnToday": "امروز"
		}
	},
	"timePicker": {
		"enabled": false,
		"step": 1,
		"hour": {
			"enabled": false,
			"step": null
		},
		"minute": {
			"enabled": false,
			"step": null
		},
		"second": {
			"enabled": false,
			"step": null
		},
		"meridian": {
			"enabled": false
		}
	},
	"dayPicker": {
		"enabled": true,
		"titleFormat": "YYYY MMMM"
	},
	"monthPicker": {
		"enabled": true,
		"titleFormat": "YYYY"
	},
	"yearPicker": {
		"enabled": true,
		"titleFormat": "YYYY"
	},
	"responsive": false
});