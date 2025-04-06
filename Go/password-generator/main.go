package main

import (
	"fmt"
	"flag"
	"math/rand"
	"os"
	"time"
)

const (
	lowerCharSet   string = "abcdefghijklmnopqrstuvwxyz"
	upperCharSet   string = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
	specialCharSet string = "!@#$%^&*()-"
	numberCharSet  string = "123567890"
)

func main() {
	var (
		passwordLength    int
		numberOfPasswords int
		minSpecialChar    int
		minUpperChar      int
		minNumberChar     int
	)

	passwordLengthFlag 		 := flag.Int("length", 10, "Length of password to generate")
	numberOfPasswordsFlag    := flag.Int("count", 1, "Number of passwords to generate")
	minNumOfSpecialCharsFlag := flag.Int("min-special", 2, "Minimum number of special characters")
	minNumOfUpperCharsFlag   := flag.Int("min-upper", 2, "Minimum number of upper characters")
	minNumOfNumbersFlag      := flag.Int("min-number", 2, "Minimum number of numbers")

	flag.Parse()

	passwordLength    = *passwordLengthFlag
	numberOfPasswords = *numberOfPasswordsFlag
	minSpecialChar 	  = *minNumOfSpecialCharsFlag
	minUpperChar 	  = *minNumOfUpperCharsFlag
	minNumberChar 	  = *minNumOfNumbersFlag

	totalCharLenWithoutLowerChar := minUpperChar + minSpecialChar + minNumberChar

	if totalCharLenWithoutLowerChar >= passwordLength {
		fmt.Println("Provide valid password length")

		os.Exit(1)
	}

	rand.NewSource(time.Now().UnixNano())

	for i := 0; i < numberOfPasswords; i++ {
		password := generatePassword(passwordLength, numberOfPasswords, minSpecialChar, minUpperChar, minNumberChar)

		fmt.Printf("Password %v is %v \n", i + 1, password)
	}
}

func generatePassword(passwordLength int, numberOfPasswords int, minSpecialChar int, minUpperChar int, minNumberChar int) string {
	var password string

	for i := 0; i < minSpecialChar; i++ {
		random := rand.Intn(len(specialCharSet))

		password = password + string(specialCharSet[random])
	}

	for i := 0; i < minUpperChar; i++ {
		random := rand.Intn(len(upperCharSet))

		password = password + string(upperCharSet[random])
	}

	for i := 0; i < minNumberChar; i++ {
		random := rand.Intn(len(numberCharSet))

		password = password + string(numberCharSet[random])
	}

	totalCharLenWithoutLowerChar := minUpperChar + minSpecialChar + minNumberChar

	remainingCharLen := passwordLength - totalCharLenWithoutLowerChar

	for i := 0; i < remainingCharLen; i++ {
		random := rand.Intn(len(lowerCharSet))

		password = password + string(lowerCharSet[random])
	}

	passwordRune := []rune(password)

	rand.Shuffle(len(passwordRune), func(i, j int) {
		passwordRune[i], passwordRune[j] = passwordRune[j], passwordRune[i]
	})

	password = string(passwordRune)

	return password
}
