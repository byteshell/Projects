package main

import (
	"fmt"
	"net/http"
	"net/smtp"
	"os"
	"time"
)

var websites = map[string]int{
	"https://youtube.com": 200,
	"https://google.com":  200,
	"http://localhost":    200,
}

const checkInterval int = 5
const reminderInterval int = 5

type WebStatus struct {
	web string
	status string
	lastFailure time.Time
}

var sentFrom = os.Getenv("GMAIL_ID")
var password = os.Getenv("GMAIL_PASSWORD")

var sendTo = []string{
	os.Getenv("GMAIL_ID"),
}

var smtpHost = os.Getenv("SMTP_HOST")
var smtpPort = os.Getenv("SMTP_PORT")

func main() {
	var webStatusSlice []WebStatus

	for {
		if len(webStatusSlice) == 0 {
			fmt.Println("All websites are working now.")
		}

		for web, expectedStatusCode := range websites {
			res, err := http.Get(web)

			if err != nil {
				alertUser(web, err, &webStatusSlice)

				continue
			} else {
				if res.StatusCode != expectedStatusCode {
					errMsg := fmt.Errorf("%v is down", web)

					alertUser(web, errMsg, &webStatusSlice)
				}
			}
		}

		fmt.Printf("Sleep for %v seconds \n", checkInterval)

		time.Sleep(time.Duration(checkInterval) * time.Second)
	}
}

func alertUser(web string, err error, webStatusSlice *[]WebStatus) {
	downWebInfo := WebStatus{web: web, status: "down", lastFailure: time.Now()}

	if len(*webStatusSlice) == 0 {
		previousAlert := checkForPreviousAlert(webStatusSlice, web)

		if !previousAlert {
			fmt.Printf("%v added to alert list \n", web)
			*webStatusSlice = append(*webStatusSlice, downWebInfo)
			triggerEmail(web)
		} else {
			fmt.Printf("%v already on the list \n", err)
			triggerAnother := checkForReminderInterval(webStatusSlice, web)

			if triggerAnother {
				triggerEmail(web)
			}
		}
	} else {
		fmt.Printf("%v added to alert list \n", web)
		*webStatusSlice = append(*webStatusSlice, downWebInfo)
		triggerEmail(web)
	}
}

func checkForPreviousAlert(webStatusSlice *[]WebStatus, web string) bool {
	alreadyDown := false

	for _, webStatusInfo := range *webStatusSlice {
		if webStatusInfo.web == web {
			alreadyDown = true
		}
	}

	if !alreadyDown {
		return false
	} else {
		return true
	}
}

func triggerEmail(web string) {
	message := []byte("Subject: Web Monitor Alert System \r\n\r\n" + web + " - Website is down\r\n")

	auth := smtp.PlainAuth("", sentFrom, password, smtpHost)

	err := smtp.SendMail(smtpHost + ":" + smtpPort, auth, sentFrom, sendTo, message)

	if err != nil {
		fmt.Println(err)

		return
	}

	fmt.Println("Email sent successfully")
}

func checkForReminderInterval(webStatusSlice *[]WebStatus, web string) bool {
	triggerAnother := false

	for i, webStatusInfo := range *webStatusSlice {
		if webStatusInfo.web == web {
			lastFailurePlusReminder := webStatusInfo.lastFailure.Add(time.Duration(reminderInterval) * time.Minute)

			if lastFailurePlusReminder.Before(time.Now()) {
				triggerAnother = true

				(*webStatusSlice)[i] = WebStatus{web: web, status: "down", lastFailure: time.Now()}

				fmt.Printf("%v - time for new alert \n", web)
			} else {
				fmt.Printf("%v - next alert will be send after reminder interval \n", web)
			}
		}
	}

	return triggerAnother
}
