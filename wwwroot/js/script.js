const URL = 'https://localhost:7255/api/mails'

const container = document.querySelector('table.listUrl');

const email = document.querySelector('.email')
const subject = document.querySelector('.subject')
const messages = document.querySelector('.messages')
const sendData = document.querySelector('.sendData')


getData(URL)

function getData(url){
    fetch(url)
        .then(res => {
        return res.json()
    })
        .then((data) => {
            data.map((p) => {
                let createTable = document.createElement('tr')
                let recepient = document.createElement('td')
                let subject = document.createElement('td')
                let messages = document.createElement('td')
                let senddateTime = document.createElement('td')
                let messageStatuses = document.createElement('td')
                let log = document.createElement('td')


                recepient.textContent = p.recepient

                subject.textContent = p.subject

                messages.textContent = p.messages

                senddateTime.textContent = p.senddateTime

                messageStatuses.textContent = p.messageStatus.result

                // Проверка на статус Failed
                if (p.messageStatus.result === 'Failed'){
                    messageStatuses.style.backgroundColor = 'red'
                }
                else {
                    messageStatuses.style.backgroundColor = 'green'
                }

                log.textContent = p.messageStatus.log

                if (container){
                    container.appendChild(createTable)
                }
                createTable.append(senddateTime,recepient,subject,messages, messageStatuses, log)
            })
        })
}

// Отправка данных на свервер
if(sendData){
    sendData.addEventListener('click', () => {
        let body = {
            Recepient: email.value,
            Subject: subject.value,
            Messages: messages.value
        }
        fetch(URL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(body)
        }).then(res => res.json());
        alert("Отправлено")
        location.reload()
    })

}

