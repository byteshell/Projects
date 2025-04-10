package main

import (
	"encoding/json"
	"fmt"
	"io"
	"net/http"
)

func FormatJSON(jsonBody []byte) ([]byte, error) {
	var prettyJSON map[string]interface{}

	err := json.Unmarshal(jsonBody, &prettyJSON)

	if err != nil {
		panic(err)
	}

	formattedJSON, err := json.MarshalIndent(prettyJSON, "", " ")

	if err != nil {
		panic(err)
	}

	return formattedJSON, err
}

func FetchURL(url string) ([]byte, error) {
	resp, err := http.Get(url)

	if err != nil {
		panic(err)
	}

	defer resp.Body.Close()

	body, err := io.ReadAll(resp.Body)

	if err != nil {
		panic(err)
	}

	return body, err
}

func main() {
	var url string

	fmt.Print("Enter a GitHub URL to fetch: ")
	_, _ = fmt.Scan(&url)

	body, _ := FetchURL(url)

	resultedJson, _ := FormatJSON(body)

	fmt.Println(string(resultedJson))
}

// https://api.github.com/repos/golang/go
