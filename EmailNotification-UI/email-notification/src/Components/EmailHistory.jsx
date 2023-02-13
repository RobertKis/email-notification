import axios from 'axios';
import React, {useEffect, useState} from 'react';
import styled from 'styled-components';

const Wrapper = styled.div`
    margin-top: 20px;
`;

const EmailTable = styled.table`
    table-layout: fixed;
    width: 100%;
    border-collapse: collapse;

    tr:nth-child(even) {
        background-color: #D6EEEE;
    }
`;

const EmailHistory = () => {
    const [emails, setEmails] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:7062/notification').then(res => {console.log(res.data); setEmails(res.data)});
    }, [])

    const renderRow = (email) => {
        return (
            <tr>
                <td>{email.from}</td>
                <td>{email.to}</td>
                <td>{email.cc.join(', ')}</td>
                <td>{email.subject}</td>
                <td>{email.content}</td>
                <td>{email.importance}</td>
            </tr>
        )
    }

    return (
        <Wrapper>
            <EmailTable>
                <thead>
                    <tr>
                        <th>From</th>
                        <th>To</th>
                        <th>CC</th>
                        <th>Subject</th>
                        <th>Content</th>
                        <th>Importance</th>
                    </tr>
                </thead>
                <tbody>
                    {emails.map(e => renderRow(e))}
                </tbody>
            </EmailTable>            
        </Wrapper>
    )
}

export default EmailHistory;