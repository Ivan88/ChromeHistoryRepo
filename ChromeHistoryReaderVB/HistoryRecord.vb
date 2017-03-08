Public Class HistoryRecord
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set
            m_Id = Value
        End Set
    End Property
    Private m_Id As Integer
    Public Property Url() As String
        Get
            Return m_Url
        End Get
        Set
            m_Url = Value
        End Set
    End Property
    Private m_Url As String
    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set
            m_Title = Value
        End Set
    End Property
    Private m_Title As String
    Public Property VisitedDate() As DateTime
        Get
            Return m_VisitedDate
        End Get
        Set
            m_VisitedDate = Value
        End Set
    End Property
    Private m_VisitedDate As DateTime
    Public Property VisitCount() As Integer
        Get
            Return m_VisitCount
        End Get
        Set
            m_VisitCount = Value
        End Set
    End Property
    Private m_VisitCount As Integer
    Public Property TypedCount() As Integer
        Get
            Return m_TypedCount
        End Get
        Set
            m_TypedCount = Value
        End Set
    End Property
    Private m_TypedCount As Integer
End Class
